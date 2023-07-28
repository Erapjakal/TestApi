using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class DatumEntity
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("table_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("table_name")]
        public string TableName { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sort")]
        public object Sort { get; set; }
    }

    public class Entity
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumEntity> Data { get; set; }
    }
}
