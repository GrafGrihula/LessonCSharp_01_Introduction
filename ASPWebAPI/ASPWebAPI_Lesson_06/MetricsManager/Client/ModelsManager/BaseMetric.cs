using System;
using System.Text.Json.Serialization;

namespace MetricsManager.Client.Models
{
    public class BaseMetric
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
    }
}
