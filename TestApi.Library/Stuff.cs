using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class StuffDatum
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<StuffEmail> Email { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonProperty("registered", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("registered")]
        public bool Registered { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthday")]
        public int? Birthday { get; set; }

        [JsonProperty("specialization", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("specialization")]
        public string Specialization { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("auth_user_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("auth_user_id")]
        public object AuthUserId { get; set; }

        [JsonProperty("is_app_bot", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_app_bot")]
        public bool IsAppBot { get; set; }

        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonProperty("aboutMyself", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("aboutMyself")]
        public string AboutMyself { get; set; }

        [JsonProperty("showBirthYear", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("showBirthYear")]
        public bool ShowBirthYear { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<StuffPhone> Phone { get; set; }

        [JsonProperty("departmentsIds", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("departmentsIds")]
        public List<string> DepartmentsIds { get; set; }

        [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

        [JsonProperty("socialMedia", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("socialMedia")]
        public List<StuffSocialMedium> SocialMedia { get; set; }
    }
    public class StuffEmail
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonProperty("main", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("main")]
        public bool Main { get; set; }
    }
    public class StuffMeta
    {
        [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonProperty("last_page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
    public class StuffPhone
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
    public class Stuff
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<StuffDatum> Data { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public StuffMeta Meta { get; set; }
    }
    public class StuffSocialMedium
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
