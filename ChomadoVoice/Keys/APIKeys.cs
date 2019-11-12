using System;

namespace ChomadoVoice.Keys
{
    class APIKeys
    {
        // ここに、VoiceTextWebApiで自分で取得したAPIキーを入れてね！
        // 又は、以下の行を残し、AzureポータルのAzure Functionアプリケーション「アプリケーション設定」→「アプリケーション設定」でVoiceText APIキーを設定します。
        // Environment.GetEnvironmentalVariable(...)は、ハードコーディングすることなく、この値を安全に参照します
        public static readonly string VoiceTextWebApiKey = Environment.GetEnvironmentVariable("VoiceTextWebApiKey");
    }
}
