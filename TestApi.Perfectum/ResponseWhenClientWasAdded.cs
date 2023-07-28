using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class ResponseWhenClientWasAdded
    {
        [JsonPropertyName("status")]
        public bool? Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
