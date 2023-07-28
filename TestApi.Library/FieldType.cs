using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class DatumField
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("db_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("db_type")]
        public string DbType { get; set; }

        [JsonProperty("multiple", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("multiple")]
        public int Multiple { get; set; }
    }
    public class FieldType
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumField> Data { get; set; }
    }
}
