from emopy import FERModel

class FERModelEnsemble:
    def __init__(self):
        self.emotions = ['anger', 'fear', 'calm', 'sadness', 'happiness', 'surprise', 'disgust']
        self.models = [] # list of pretrained FER models
        self.supported_emotion_subsets = [
            set(['anger', 'fear', 'surprise', 'calm']),
            set(['happiness', 'disgust', 'surprise']),
            set(['anger', 'fear', 'surprise']),
            set(['anger', 'fear', 'calm']),
            set(['anger', 'happiness', 'calm']),
            set(['anger', 'fear', 'disgust']),
            set(['calm', 'disgust', 'surprise']),
            set(['sadness', 'disgust', 'surprise']),
            set(['anger', 'happiness'])]

        for subset in self.supported_emotion_subsets:
            self.models.append(FERModel(subset, verbose=False))

    def predict_frame(self, image):
        # list of dictionaries, each containing the predictions of one FER model
        results = [model.predict_frame(image) for model in self.models]

        predictions = self.combine_predictions(results)

        return predictions

    def combine_predictions(self, results):
        # TODO: combine results in a smarter way [maybe taking into account the size of each subset]
        # combine the results and normalize
        predictions = {e: 0 for e in self.emotions}
        for res_dict in results:
            for key, value in res_dict.items():
                predictions[key] += value

        # normalize
        sum_ = sum(predictions.values())
        predictions = {k: v / sum_ for k, v in predictions.items()}
        return predictions



