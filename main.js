const VoiceTextWriter = require('./VoiceTextWriter');
const googlehome = require('google-home-notifier');
const fs = require('fs');
const language = 'ja';

const keys = JSON.parse(fs.readFileSync('Keys/APIKeys.json'));
const script = fs.readFileSync('script.txt');
const azure = require('azure-storage');

googlehome.device('Google-Home', language); 

/* 普通に Google Home のお姉さんの声で読み上げて欲しいなら、これだけでOK
googlehome.notify('こんにちは、ちょまどです！', function(res) {
  console.log(res);
});
*/

// (しかし、私はGoogleHomeの女性の声ではなく、男性の声で喋って欲しい。でもGoogle Home には男性の声に対応していないので、
// わざわざテキストを「VoiceText Web API」に投げて男性の声で喋った mp3 を取得して Azure Storage に投げる→喋らせる、という手順)

// 音声ファイルを作る.
const voiceTextWriter = new VoiceTextWriter(keys.voiceText);
voiceTextWriter.convertToText(script).then( function(mp3) {
  // Azure の Storage にコンテナーを作る処理
  var blobService = azure.createBlobService(keys.storageAccount, keys.accessKey);
  blobService.createContainerIfNotExists('mp3', {
    publicAccessLevel: 'blob'
  }, function(error, result, response) {
    if (error) {
      console.log(error.message);
      return;
    }
    // アップロードする
    blobService.createBlockBlobFromLocalFile('mp3', 'voice.mp3', mp3, function(error, result, response) {
      if (error) {
        console.log(error.message);
        return;
      }
      // Google Home で再生
      googlehome.play(`https://${keys.storageAccount}.blob.core.windows.net/${result.container}/${result.name}`, function(res) {
        console.log(res);
      });
    });
  });
},
function(error) {
  console.log(error.message);
});


