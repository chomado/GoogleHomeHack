# Google Home Hack
Google Home に好きな声で喋らせるものです。

書いたコードは全て上げていますが、    
clone 後、以下 3 つは貴方が自分でやらなければなりません。（アカウントの都合上）

1. VoiceText Web API の APIキー取得
2. [Microsoft Azure Blob Storage](https://azure.microsoft.com/ja-jp/services/storage/blobs/) (mp3保存場所)のインスタンス立ち上げる
3. Microsoft Azure Blob Storage (mp3保存場所)の APIキー２つ取得

<blockquote class="twitter-tweet" data-lang="ja"><p lang="ja" dir="ltr">Google Home って女性の声しか無いんですけど、<br><br> 私たくましい男の人に喋ってもらいたかったので<br><br>プログラミングしました😀<br><br>Node .jsで書きました。<br><br>Voice Text API と<br>MSのクラウドサービス Azure Blob Storage 使用<br><br>書いたコード:<a href="https://t.co/K5KnzegMCy">https://t.co/K5KnzegMCy</a><br><br>デモ↓(動画(音出して聞いてね！)) <a href="https://t.co/Ha7vrbFpW1">pic.twitter.com/Ha7vrbFpW1</a></p>&mdash; ちょまど🎍ギックリ腰&amp;Fate視聴中 (@chomado) <a href="https://twitter.com/chomado/status/953832898842341376?ref_src=twsrc%5Etfw">2018年1月18日</a></blockquote>
<script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>


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
