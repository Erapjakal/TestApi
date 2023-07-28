using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class TokenResponse
    {
        [JsonProperty("jwt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("jwt")]
        public string? Jwt { get; set; }

        [JsonProperty("refreshToken", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("refreshToken")]
        public string? RefreshToken { get; set; }

        [JsonProperty("expireInSeconds", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("expireInSeconds")]
        public int ExpireInSeconds { get; set; }
    }
}
