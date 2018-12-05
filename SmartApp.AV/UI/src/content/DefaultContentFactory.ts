import { ContentFactory, IContent, AudioContent, SpeechContent, TextContent, GenericContent } from './Content';
import { ElfUIEvent, KEY_CONTENT } from '../ui/event/ElfUIEvent';

import * as Logger from '../log/Logger';
import { ValenceArousalEmotion } from '../emotion/Emotion';

/**
 * Default implementation of ContentFactory
 */
export class DefaultContentFactory implements ContentFactory {

    create(event: ElfUIEvent): Array<IContent> {
        let data = event.getAny(KEY_CONTENT);

        let contents = [];
        for (var key in data) {
            switch (key) {
                case "audio":
                    try {
                        let emotionData: {valence: number, arousal: number} = {
                            valence: data[key]['valence'],
                            arousal: data[key]['arousal']
                        },
                            audioB64 = data[key]['audio'];

                        let emotion = new ValenceArousalEmotion(emotionData.valence, emotionData.arousal);

                        contents.push(new AudioContent(emotion, audioB64));
                    } catch (ex) {
                        Logger.getInstance().log(Logger.LEVEL.ERROR, "Cannot elaborate audio file", data, ex);
                    }
                    break;
                case "speech":
                    try {
                        let text = data[key]['text'];
                        let emotionData: {valence: number, arousal: number} = data[key]['emotion'];

                        let emotion = new ValenceArousalEmotion(emotionData.valence, emotionData.arousal);

                        if (text && emotion) {
                            contents.push(new SpeechContent(text, emotion));
                        } else {
                            Logger.getInstance().log(Logger.LEVEL.ERROR, "Cannot get all data from speech content", data[key]);
                        }
                    } catch (ex) {
                        Logger.getInstance().log(Logger.LEVEL.ERROR, "Cannot get data from speech content", data[key], ex);
                    }
                    break;
                case "text":
                    let text = data[key];
                    if (text) {
                        contents.push(new TextContent(text));
                    }
                    break;
                default:
                    let d = {};
                    d[key] = data[key];
                    contents.push(new GenericContent(d));
                    break;
            }
        }

        return contents;
    }

}