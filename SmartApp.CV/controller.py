from external_modules.kb_client import KnowledgeBaseClient as kb
import external_modules.hal_client as hal
from online.online_module import online_module as online
from offline.offvision import OffVision as offline

from face_db import face_db as db

from threading import Thread
from queue import Queue
import cv2

# TODO:  inserire il Thread che salva el face_db
# TODO: risolvere il problema del del limite inesistente su Face++

#  IDEA: Si possono avere più queue (almeno 6 dato che 6 è il numero massimo di
#  facce riconosciute simultaneamente dal kinekt) che matengo in memoria i frame
#  di ogni faccia che ha lo stesso id (dato da HAL-kinekt) cosi da poter avere
#  diversi thread che eseguono le richieste al modulo separatamente per ogni
#  persona. Cosi facendo sarà necesssario eseguire l'identifica solo una volta,
#  la prima volta, e non eseguirla più fino a quando non subentra una nuova
#  immagine con un nuovo id (l'id è un id generato dal kinekt per quella faccia)
#
#  Vedere il file StreamWebCam per un esempio di implementazione
#  (fatto da Michele in script/StreamWebCam)
#

DOCS = {
'VISION_FACE_ANALYSIS': {
    'doc':"""{
        'personID': identifier of the face descriptor,
        'emotion': {
            'sadness':   confidence in float [0,1],
            'calm':      confidence in float [0,1],
            'disgust':   confidence in float [0,1],
            'anger':     confidence in float [0,1],
            'surprise':  confidence in float [0,1],
            'fear':      confidence in float [0,1],
            'happiness': confidence in float [0,1]
        },
        'gender': predicted gender of person ['Male', 'Female', 'Unknown']
        'age': predicted age of person -- int [0-99] U {-1} if unknown,
        'smile': whether the person is smiling -- ['True', 'False', 'Unknown'],
        'known': whether the person has been already seen -- ['True', 'False', 'Unknown'],
        'confidence_identity': confidence of face matching -- float [0-1],
        'look_at': {
            'pinch': position to look in y axis -- float [-1 - +1],
            'yaw': position to look in y axis -- float [-1 - +1]
        }
        'is_interlocutor': whether the person is the interlocutor -- ['True', 'False']
        'z_index': distance of person from kinekt -- {-1} if unknown
    }""",
    'desc': """Json that contain all needed information of single face, the TTL of
        this information is about 2 seconds (time of elaboration of single file)"""
}}

class Controller():

    #FIFO queue
    q = Queue(maxsize= 5)

    def __init__(self, host = "10.101.41.242"):
        """
            se host è webcam uso la webcam
        """
        # Ops for KB
        #self._kb = kb(persistence = True)
        # mi registrerò
        #self._kb.registerTags(DOCS)

        # Ops for stream in input
        self.is_host = not (host == "webcam")
        self._hal = None
        self._videoID = None
        self.video_capture = None

        if self.is_host:
            self._hal = hal.HALInterface(HALAddress= host)
            self._videoID = self._hal.registerAsVideoReceiver(Controller._take_frame)
            if self._videoID == -1:
                print("Ops!, something wrong happens during the interaction with the HALModule. (Video)")
                exit(-1)
        else:
            self.video_capture = cv2.VideoCapture(0)

        # DB initialization
        self.db = db()
        self.t = None

        # Initialization of Online Module
        try:
            self.online_module = online()
            self.has_api_problem = False
        except Exception as e:
            self.has_api_problem = True
            print(type(e).__name__, e)
            print("\n It seems that there is a problem with the online module: I'm swithing to offline module...")
        # option to retry initialization if it has failed (eg, no internet connection during init)
        self.retry_init_online_module = False

        # Initialization of Offline Module
        try:
            self.offline_module = offline()
        except Exception as e:
            print(type(e).__name__, e)
            print("\n It seems that there is a problem in the initialization!")

        # Ops for worker that compute all the analyzes
        self.t = Thread(target=Controller._worker, args=[self, Controller.q])
        self.t.daemon = True
        self.t.start()

        # Initialization of exponential backoff machanism
        self.attempt = 0
        self.exponent = 1
        self.max_exponent = 8
        # decide what to do with online module initialization failure
        if self.has_api_problem:
            if self.retry_init_online_module:
                # retry init over longest interval
                self.exponent = self.max_exponent
                self.attempt = 2 ** self.exponent
            else:
                # always go offline
                self.attempt = float('inf')

    def _take_frame(frame_obj):
        """
            Function of callback used from HAL group to send a frame

            Params:
                frame_obj (object): object that contain all image of face in a
                    frame
        """
        if Controller.q.full():
            Controller.q.get()
        for face in frame_obj.faces:
            Controller.q.put((face.img, frame_obj.frame_original_size))

    def _get_id_person(self, fact, tuple, img):
        if fact is not None and tuple is not None:
            res = self.db.soft_get(tuple)
            # res = [ [ tuple1, confidence1 ] ... [tuple_n, confidence_n] ]

            if len(res) > 0: #something matches
                vals = [res[0][0], res[0][1], True]

            elif self.has_api_problem: #offline module case
                vals = [self.db.insert(tuple), 0, False]

            else: #online module case
                descriptor = self.offline_module.get_descriptor(img)

                res = self.db.soft_get((descriptor, None))
                if len(res) > 0: #something matches
                    #return ID and update record with the token
                    vals = [res[0][0], res[0][1], True]
                    self.db[fact['personID']] = (descriptor, None)
                else:
                    #no match add it to db
                    vals = [self.db.insert((descriptor, None)), 0, False]

            print("\tHo scitto:")
            atts = ['personID', 'confidence_identity', 'known']
            for att, val in zip(atts, vals):
                fact.update({att:val})
                print("\t\t"+str(att)+":"+str(val))

            print("\tOra il db è:"+ str(self.db))

        return fact

    def _worker(self, queue):
        """
            Function of thread that compute all the analyzes of frame.

            Params:
                queue (Queue): queue associated at thrad of frame
        """
        print("inizio Worker")
        face_obj, frame_size, img = None, None, None
        while True:
            try:
                print("Prendo Frame")
                if self.is_host:
                    face_obj, frame_size  = queue.get()
                    img = face_obj.img
                    queue.task_done()
                else: # TODO: delete this option only for test
                    ret, frame = self.video_capture.read()
                    frame_size = (320, 240)
                    img = face_obj = cv2.resize(frame, frame_size)

                print("Inizio Watch")
                fact, tuple = self.watch(face_obj, frame_size)
                # tuple = (descriptor, token)
                print("Ho visto chi sta: "+str((fact, tuple))+"\n data"+str(self.db))
                print("Inizio _get_id_person")
                fact = self._get_id_person(fact, tuple, img)
                print("Ora so:"+str(fact))

                #self._add_fact_to_kb(fact)
            except Exception as e:
                print("_worker function ->"+type(e).__name__, e)

    def _add_fact_to_kb(self, fact, tag='VISION_FACE_ANALYSIS'):
        try:
            self._kb.addFact("face", tag, 1, jsonFact=fact, reliability=fact['confidence_identity'])
        except Exception as e:
            print("Could not add fact", e)

    def _bake_off(self, img):
        try:
            print("\t\tVerifico quale modulo utilizzare")
            if self.attempt < 1: # attempt an online analysis
                if self.has_api_problem and self.retry_init_online_module:
                    print("\t\tReinizializzo Online")
                    self.online_module = online()
                    self.has_api_problem = False
                print("\t\tUtilizzo Online")
                fact, tuple = self.online_module.analyze_face(img)
                self.exponent = 1 # all fine, reset backoff
            else: # we're in the backoff interval, work offline
                print("\t\tUtilizzo Offline")
                fact, tuple = self.offline_module.analyze_face(img)
                self.attempt -= 1 # one more attempt done
                # print('*** BACKOFF attempt', self.attempt, 'of exponent', self.exponent, '***')
        except Exception as e:
            print("\t\t\tErrore Durante l'utilizzo del Modulo")
            print("_bake_off Function ->" + type(e).__name__, e)
            # something went wrong, double the attempt interval (until maximum length)
            if self.exponent < self.max_exponent:
                self.exponent += 1
            # begin the new backoff interval
            self.attempt = 2 ** self.exponent
            # remeber, we've still to analyze this face:
            print("\t\t\tUtilizzo Offline per rimediare")
            fact, tuple = self.offline_module.analyze_face(img)

        return fact, tuple

    def watch(self, face, frame_size = (0,0)):
        print("\tInizio bakeOff")
        fact, tuple = self._bake_off(face.img if hasattr(face, "img") else face)
        print("\tFine bakeOff")

        print("\tInizio integrazione fact")
        if fact:
            look_at = {'pinch': 0, 'yaw':0}
            if set(frame_size)==0:
                face_position = face.face_position if hasattr(face, "face_position") else (0, 0)
                look_at = list( (p/(s/2))-1 for p,s in zip(face_position, frame_size))
                look_at = {'pinch': look_at[0], 'yaw': look_at[1]}

            fact.update({
                "look_at": look_at,
                "is_interlocutor": face.is_interlocutor if hasattr(face, "is_interlocutor") else False,
                "z_index": face.z_index if hasattr(face, "z_index") else -1,
            })
        else:
            print("Non vedo nessuno")

        print("\tFine integrazione fact")
        return fact, tuple

    def close(self):
        print("Chiusura controller")

        if self._hal is not None:
            self._hal.unregister(self._videoID)
            self._hal.quit()
        Controller.q.join()
        self.db.close()
        # if self.t is not None:
        #     self.t.join()

    def __del__(self):
        self.close()


if __name__ == '__main__':
    controller = Controller(host = "webcam")
    input('Enter anything to close:')
    controller.close()
