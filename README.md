# Google Home Hack
Google Home に好きな声で喋らせるものです。

書いたコードは全て上げていますが、    
clone 後、以下 3 つは貴方が自分でやらなければなりません。（アカウントの都合上）

1. VoiceText Web API の APIキー取得
2. [Microsoft Azure Blob Storage](https://azure.microsoft.com/ja-jp/services/storage/blobs/) (mp3保存場所)のインスタンス立ち上げる
3. Microsoft Azure Blob Storage (mp3保存場所)の APIキー２つ取得

## 動作デモ

必ず見てください！80秒間です

[https://twitter.com/chomado/status/953832898842341376]

## Background

Google Home への接続は `google-home-notifier` パッケージ様を使っています。

これは本当に便利なライブラリで、

例えば、普通に Google Home のお姉さんの声で読み上げて欲しいなら、
````js
googlehome.notify('こんにちは、ちょまどです！', function(res) {
  console.log(res);
});
````
これだけで動きます。

`開発PC` → `Google Home`

しかし、今回、私はたくましい男の人に喋ってほしかったので、[VoiceText Web API](https://cloud.voicetext.jp/webapi)を使用しました。

`開発PC` → `VoiceText Web API`(声変換) → `Microsoft Azure Blob Storage`(mp3保存) → `Google Home`

なので、少しだけ複雑になっていますが、大丈夫です。
