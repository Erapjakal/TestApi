using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class Contacts
    {
        [JsonProperty("15", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("15")]
        public string? _15 { get; set; }

        [JsonProperty("16", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("16")]
        public string? _16 { get; set; }
    }
    public class CustomFields
    {
        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public Contacts? Contacts { get; set; }
    }
    public class ClientContactToConvert
    {
        [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("userid")]
        public string? Userid { get; set; }

        [JsonProperty("firstname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("firstname")]
        public string? Firstname { get; set; }

        [JsonProperty("lastname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lastname")]
        public string? Lastname { get; set; }

        [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("patronymic")]
        public string? Patronymic { get; set; }

        [JsonProperty("profile_image", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("profile_image")]
        public string? ProfileImage { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonProperty("email_additional", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email_additional")]
        public string? EmailAdditional { get; set; }

        [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber")]
        public string? Phonenumber { get; set; }

        [JsonProperty("phonenumber_additional", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber_additional")]
        public string? PhonenumberAdditional { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthday")]
        public string? Birthday { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonProperty("is_primary", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_primary")]
        public string? IsPrimary { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("active")]
        public string? Active { get; set; }

        [JsonProperty("donotsendwelcomeemail", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("donotsendwelcomeemail")]
        public string? Donotsendwelcomeemail { get; set; }

        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("permissions")]
        public List<string>? Permissions { get; set; }

        [JsonProperty("invoice_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("invoice_emails")]
        public string? InvoiceEmails { get; set; }

        [JsonProperty("project_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("project_emails")]
        public string? ProjectEmails { get; set; }

        [JsonProperty("ticket_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ticket_emails")]
        public string? TicketEmails { get; set; }

        [JsonProperty("task_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("task_emails")]
        public string? TaskEmails { get; set; }

        [JsonProperty("contract_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contract_emails")]
        public string? ContractEmails { get; set; }

        [JsonProperty("proposal_emails", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("proposal_emails")]
        public string? ProposalEmails { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("custom_fields")]
        public CustomFields? CustomFields { get; set; }
    }
}
