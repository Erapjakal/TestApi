using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class LeadCustomFields
    {
        [JsonProperty("leads", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("leads")]
        public Leads Leads { get; set; }
    }
    public class Leads
    {
        [JsonProperty("18", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("18")]
        public string _18 { get; set; }

        [JsonProperty("20", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("20")]
        public string _20 { get; set; }
    }
    public class Lead
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonProperty("assigned", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("assigned")]
        public string Assigned { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonProperty("client_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("surname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("email_additional", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_additional")]
        public string EmailAdditional { get; set; }

        [JsonProperty("instagram", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("instagram")]
        public string Instagram { get; set; }

        [JsonProperty("whatsapp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("whatsapp")]
        public string Whatsapp { get; set; }

        [JsonProperty("telegram", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("telegram")]
        public string Telegram { get; set; }

        [JsonProperty("viber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("viber")]
        public string Viber { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("phonenumber_additional", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber_additional")]
        public string PhonenumberAdditional { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_public")]
        public string IsPublic { get; set; }

        [JsonProperty("contacted_today", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacted_today")]
        public string ContactedToday { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("custom_fields")]
        public LeadCustomFields CustomFields { get; set; }
    }
}
