using System;
using Newtonsoft.Json;

namespace MESOPCServerMinimalAPI.DTO
{
    public class TagData
    {
        [JsonProperty("tag")]
        public string? Tag { get; set; }

        [JsonProperty("value")]
        public object? Value { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("quality")]
        public string? Quality { get; set; }
    }
}
