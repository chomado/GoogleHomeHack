using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ChomadoVoice.Models
{
    /// <summary>
    /// DialogFlow から渡ってくる JSON をパースする用
    /// </summary>
    public class DialogFlowResponseModel
    {
        [JsonProperty("originalRequest")]
        public OriginalRequest OriginalRequest { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public partial class OriginalRequest
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("isInSandbox")]
        public bool IsInSandbox { get; set; }

        [JsonProperty("surface")]
        public Urface Surface { get; set; }

        [JsonProperty("inputs")]
        public Input[] Inputs { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("conversation")]
        public Conversation Conversation { get; set; }

        [JsonProperty("availableSurfaces")]
        public Urface[] AvailableSurfaces { get; set; }
    }

    public partial class Urface
    {
        [JsonProperty("capabilities")]
        public Capability[] Capabilities { get; set; }
    }

    public partial class Capability
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Conversation
    {
        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("conversationToken")]
        public string ConversationToken { get; set; }
    }

    public partial class Input
    {
        [JsonProperty("rawInputs")]
        public RawInput[] RawInputs { get; set; }

        [JsonProperty("arguments")]
        public Argument[] Arguments { get; set; }

        [JsonProperty("intent")]
        public string Intent { get; set; }
    }

    public partial class Argument
    {
        [JsonProperty("rawText")]
        public string RawText { get; set; }

        [JsonProperty("textValue")]
        public string TextValue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class RawInput
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("inputType")]
        public string InputType { get; set; }
    }

    public partial class User
    {
        [JsonProperty("lastSeen")]
        public System.DateTimeOffset LastSeen { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty("parameters")]
        public ResultParameters Parameters { get; set; }

        [JsonProperty("contexts")]
        public Context[] Contexts { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parameters")]
        public JObject Parameters { get; set; }

        [JsonProperty("lifespan")]
        public long Lifespan { get; set; }
    }
    
    public partial class Fulfillment
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }

        [JsonProperty("messages")]
        public Message[] Messages { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("speech")]
        public string Speech { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("matchedParameters")]
        public MatchedParameter[] MatchedParameters { get; set; }

        [JsonProperty("intentName")]
        public string IntentName { get; set; }

        [JsonProperty("isResponseToSlotfilling")]
        public bool IsResponseToSlotfilling { get; set; }

        [JsonProperty("intentId")]
        public string IntentId { get; set; }

        [JsonProperty("webhookUsed")]
        public string WebhookUsed { get; set; }

        [JsonProperty("webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }

        [JsonProperty("nluResponseTime")]
        public long NluResponseTime { get; set; }
    }

    public partial class MatchedParameter
    {
        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("dataType")]
        public string DataType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("isList")]
        public bool IsList { get; set; }
    }

    public partial class ResultParameters
    {
        [JsonProperty("objective")]
        public string Objective { get; set; }

        [JsonProperty("Verb")]
        public string Verb { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("webhookTimedOut")]
        public bool WebhookTimedOut { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
