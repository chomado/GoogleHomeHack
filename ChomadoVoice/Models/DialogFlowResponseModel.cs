namespace ChomadoVoice.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DialogFlowRequestModel
    {
        [JsonProperty("responseId")]
        public string ResponseId { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("queryResult")]
        public QueryResult QueryResult { get; set; }

        [JsonProperty("originalDetectIntentRequest")]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
    }

    public partial class OriginalDetectIntentRequest
    {
    }

    public partial class QueryResult
    {
        [JsonProperty("queryText")]
        public string QueryText { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("allRequiredParamsPresent")]
        public bool AllRequiredParamsPresent { get; set; }

        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages")]
        public FulfillmentMessage[] FulfillmentMessages { get; set; }

        [JsonProperty("outputContexts")]
        public OutputContext[] OutputContexts { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("intentDetectionConfidence")]
        public long IntentDetectionConfidence { get; set; }

        [JsonProperty("diagnosticInfo")]
        public OriginalDetectIntentRequest DiagnosticInfo { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }

    public partial class FulfillmentMessage
    {
        [JsonProperty("text")]
        public Text Text { get; set; }
    }

    public partial class Text
    {
        [JsonProperty("text")]
        public string[] TextText { get; set; }
    }

    public partial class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public partial class OutputContext
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lifespanCount")]
        public long LifespanCount { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    public partial class Parameters
    {
        [JsonProperty("param")]
        public string Param { get; set; }
    }

    public partial class DialogFlowRequestModel
    {
        public static DialogFlowRequestModel FromJson(string json) => JsonConvert.DeserializeObject<DialogFlowRequestModel>(json, ChomadoVoice.Models.Converter.Settings);
    }

    public static class SerializeRequest
    {
        public static string ToJson(this DialogFlowRequestModel self) => JsonConvert.SerializeObject(self, ChomadoVoice.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }


    public partial class DialogFlowResponseModel
    {
        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages")]
        public FulfillmentMessage[] FulfillmentMessages { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("outputContexts")]
        public OutputContext[] OutputContexts { get; set; }

        [JsonProperty("followupEventInput")]
        public FollowupEventInput FollowupEventInput { get; set; }
    }

    public partial class FollowupEventInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    public partial class FulfillmentMessage
    {
        [JsonProperty("card")]
        public Card Card { get; set; }
    }

    public partial class Card
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("imageUri")]
        public Uri ImageUri { get; set; }

        [JsonProperty("buttons")]
        public Button[] Buttons { get; set; }
    }

    public partial class Button
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("postback")]
        public Uri Postback { get; set; }
    }

    public partial class Payload
    {
        [JsonProperty("google")]
        public Google Google { get; set; }

        [JsonProperty("facebook")]
        public Facebook Facebook { get; set; }

        [JsonProperty("slack")]
        public Facebook Slack { get; set; }
    }

    public partial class Facebook
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Google
    {
        [JsonProperty("expectUserResponse")]
        public bool ExpectUserResponse { get; set; }

        [JsonProperty("richResponse")]
        public RichResponse RichResponse { get; set; }
    }

    public partial class RichResponse
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("simpleResponse")]
        public SimpleResponse SimpleResponse { get; set; }
    }

    public partial class SimpleResponse
    {
        [JsonProperty("textToSpeech")]
        public string TextToSpeech { get; set; }

        [JsonProperty("ssml")]
        public string SSML { get; set; }

        [JsonProperty("display_text")]
        public string DisplayText { get; set; }
    }

    public partial class DialogFlowResponseModel
    {
        public static DialogFlowResponseModel FromJson(string json) => JsonConvert.DeserializeObject<DialogFlowResponseModel>(json, ChomadoVoice.Models.Converter.Settings);
    }

    public static class SerializeResponse
    {
        public static string ToJson(this DialogFlowResponseModel self) => JsonConvert.SerializeObject(self, ChomadoVoice.Models.Converter.Settings);
    }

}