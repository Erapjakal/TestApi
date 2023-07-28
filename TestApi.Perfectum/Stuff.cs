using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class StuffCustomFields
    {
        [JsonProperty("staff", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("staff")]
        public Staff Staff { get; set; }
    }

    public class StuffDatum
    {
        [JsonProperty("staffid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("staffid")]
        public string Staffid { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("facebook", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("linkedin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("skype", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("skype")]
        public string Skype { get; set; }

        [JsonProperty("telegram", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("telegram")]
        public string Telegram { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonProperty("datecreated", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("datecreated")]
        public string Datecreated { get; set; }

        [JsonProperty("last_ip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_ip")]
        public string LastIp { get; set; }

        [JsonProperty("last_login", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_login")]
        public string LastLogin { get; set; }

        [JsonProperty("last_activity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_activity")]
        public string LastActivity { get; set; }

        [JsonProperty("last_active_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_active_time")]
        public string LastActiveTime { get; set; }

        [JsonProperty("last_password_change", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_password_change")]
        public string LastPasswordChange { get; set; }

        [JsonProperty("new_pass_key", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("new_pass_key")]
        public object NewPassKey { get; set; }

        [JsonProperty("new_pass_key_requested", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("new_pass_key_requested")]
        public object NewPassKeyRequested { get; set; }

        [JsonProperty("admin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("admin")]
        public string Admin { get; set; }

        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonProperty("media_path_slug", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("media_path_slug")]
        public string MediaPathSlug { get; set; }

        [JsonProperty("is_not_staff", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_not_staff")]
        public string IsNotStaff { get; set; }

        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("hourly_rate")]
        public string HourlyRate { get; set; }

        [JsonProperty("email_signature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_signature")]
        public string EmailSignature { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("internal_phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("internal_phonenumber")]
        public string InternalPhonenumber { get; set; }

        [JsonProperty("credit_card", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("credit_card")]
        public string CreditCard { get; set; }

        [JsonProperty("email_login", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_login")]
        public string EmailLogin { get; set; }

        [JsonProperty("email_password", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_password")]
        public string EmailPassword { get; set; }

        [JsonProperty("email_client_views", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_client_views")]
        public string EmailClientViews { get; set; }

        [JsonProperty("edited_profile", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("edited_profile")]
        public string EditedProfile { get; set; }

        [JsonProperty("search_sections", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("search_sections")]
        public string SearchSections { get; set; }

        [JsonProperty("dateupdated", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("dateupdated")]
        public string Dateupdated { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("custom_fields")]
        public List<StuffCustomFields> CustomFields { get; set; }
    }

    public class Stuff
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<StuffDatum> Data { get; set; }
    }

    public class Staff
    {
        [JsonProperty("57", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("57")]
        public string Job_Title { get; set; }
    }


}
