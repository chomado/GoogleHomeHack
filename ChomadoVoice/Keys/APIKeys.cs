using System;

namespace ChomadoVoice.Keys
{
    class APIKeys
    {
        // ここに、VoiceTextWebApiで自分で取得したAPIキーを入れてね！
        public static readonly string VoiceTextWebApiKey = Environment.GetEnvironmentVariable("VoiceTextWebApiKey");
    }
}
