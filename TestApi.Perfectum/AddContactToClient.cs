using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class AddContactToClientContacts
    {
        [JsonPropertyName("15")]
        public string _15 { get; set; }

        [JsonPropertyName("16")]
        public string _16 { get; set; }
    }

    public class AddContactToClientCustomFields
    {
        [JsonPropertyName("contacts")]
        public AddContactToClientContacts Contacts { get; set; }
    }

    public class AddContactToClient
    {
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("is_primary")]
        public string IsPrimary { get; set; }

        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonPropertyName("donotsendwelcomeemail")]
        public string Donotsendwelcomeemail { get; set; }

        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; }

        [JsonPropertyName("invoice_emails")]
        public string InvoiceEmails { get; set; }

        [JsonPropertyName("project_emails")]
        public string ProjectEmails { get; set; }

        [JsonPropertyName("ticket_emails")]
        public string TicketEmails { get; set; }

        [JsonPropertyName("task_emails")]
        public string TaskEmails { get; set; }

        [JsonPropertyName("contract_emails")]
        public string ContractEmails { get; set; }

        [JsonPropertyName("proposal_emails")]
        public string ProposalEmails { get; set; }

        [JsonPropertyName("custom_fields")]
        public AddContactToClientCustomFields CustomFields { get; set; }
    }


}
