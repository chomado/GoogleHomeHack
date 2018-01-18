var fs = require('fs');
var VoiceText = require('voicetext');
var OUT_PATH = '/Users/chomado/Workspace/GoogleHomeHack/Data/mp3/temp.mp3'

class VoiceTextWriter{

    constructor(voiceKey) {
        this.voice = new VoiceText(voiceKey);
    }

	convertToText(text) {
        var self = this;
        return new Promise(function(resolve,reject) {
            self.voice
                .speaker(self.voice.SPEAKER.HIKARI)
                .emotion(self.voice.EMOTION.HAPPINESS)
                .emotion_level(self.voice.EMOTION_LEVEL.HIGH)
                .volume(150)
                .speak(text, function(e, buf) {
                    if(e){
                        console.error(e);
                        reject(e);
                    
                    } else {
                        fs.writeFileSync(OUT_PATH, buf, 'binary');
                        resolve(OUT_PATH);
                    }
                });
        });
	}
}
module.exports = VoiceTextWriter;
/*
curl "https://api.voicetext.jp/v1/tts" \
     -o "test.mp3" \
     -u "（APIキー）:" \
     -d "text=ちょまどだよー" \
     -d "speaker=bear"
     */