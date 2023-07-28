using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class Customers
    {
        [JsonProperty("9")]
        [JsonPropertyName("9")]
        public string _9 { get; set; }

        [JsonProperty("10")]
        [JsonPropertyName("10")]
        public string _10 { get; set; }

        [JsonProperty("11")]
        [JsonPropertyName("11")]
        public string _11 { get; set; }
    }
    public class ClientCustomFields
    {
        [JsonProperty("customers")]
        [JsonPropertyName("customers")]
        public Customers Customers { get; set; }

        [JsonProperty("entities")]
        [JsonPropertyName("entities")]
        public Entities Entities { get; set; }
    }
    public class Entities
    {
        [JsonProperty("2")]
        [JsonPropertyName("2")]
        public string _2 { get; set; }

        [JsonProperty("3")]
        [JsonPropertyName("3")]
        public string _3 { get; set; }

        [JsonProperty("4")]
        [JsonPropertyName("4")]
        public string _4 { get; set; }

        [JsonProperty("5")]
        [JsonPropertyName("5")]
        public string _5 { get; set; }

        [JsonProperty("6")]
        [JsonPropertyName("6")]
        public string _6 { get; set; }

        [JsonProperty("7")]
        [JsonPropertyName("7")]
        public string _7 { get; set; }

        [JsonProperty("8")]
        [JsonPropertyName("8")]
        public string _8 { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("info")]
        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonProperty("is_default")]
        [JsonPropertyName("is_default")]
        public string IsDefault { get; set; }

        [JsonProperty("billing_city")]
        [JsonPropertyName("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        [JsonPropertyName("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_zip")]
        [JsonPropertyName("billing_zip")]
        public string BillingZip { get; set; }

        [JsonProperty("billing_country")]
        [JsonPropertyName("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("billing_street")]
        [JsonPropertyName("billing_street")]
        public string BillingStreet { get; set; }

        [JsonProperty("shipping_street")]
        [JsonPropertyName("shipping_street")]
        public string ShippingStreet { get; set; }

        [JsonProperty("shipping_city")]
        [JsonPropertyName("shipping_city")]
        public string ShippingCity { get; set; }

        [JsonProperty("shipping_state")]
        [JsonPropertyName("shipping_state")]
        public string ShippingState { get; set; }

        [JsonProperty("shipping_zip")]
        [JsonPropertyName("shipping_zip")]
        public string ShippingZip { get; set; }

        [JsonProperty("shipping_country")]
        [JsonPropertyName("shipping_country")]
        public string ShippingCountry { get; set; }

        [JsonProperty("custom_fields")]
        [JsonPropertyName("custom_fields")]
        public ClientCustomFields CustomFields { get; set; }
    }
    public class Client
    {
        [JsonProperty("company")]
        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonProperty("phonenumber")]
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("website")]
        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonProperty("groups_in")]
        [JsonPropertyName("groups_in")]
        public List<string> GroupsIn { get; set; }

        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonProperty("discount_group")]
        [JsonPropertyName("discount_group")]
        public string DiscountGroup { get; set; }

        [JsonProperty("default_currency")]
        [JsonPropertyName("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonProperty("default_language")]
        [JsonPropertyName("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("billing_street")]
        [JsonPropertyName("billing_street")]
        public string BillingStreet { get; set; }

        [JsonProperty("billing_city")]
        [JsonPropertyName("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        [JsonPropertyName("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_zip")]
        [JsonPropertyName("billing_zip")]
        public string BillingZip { get; set; }

        [JsonProperty("billing_country")]
        [JsonPropertyName("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("shipping_street")]
        [JsonPropertyName("shipping_street")]
        public string ShippingStreet { get; set; }

        [JsonProperty("shipping_city")]
        [JsonPropertyName("shipping_city")]
        public string ShippingCity { get; set; }

        [JsonProperty("shipping_state")]
        [JsonPropertyName("shipping_state")]
        public string ShippingState { get; set; }

        [JsonProperty("shipping_zip")]
        [JsonPropertyName("shipping_zip")]
        public string ShippingZip { get; set; }

        [JsonProperty("shipping_country")]
        [JsonPropertyName("shipping_country")]
        public string ShippingCountry { get; set; }

        [JsonProperty("custom_fields")]
        [JsonPropertyName("custom_fields")]
        public ClientCustomFields CustomFields { get; set; }

        [JsonProperty("customer_admins")]
        [JsonPropertyName("customer_admins")]
        public List<string> CustomerAdmins { get; set; }

        [JsonProperty("entities")]
        [JsonPropertyName("entities")]
        public List<ContactClient> Entities { get; set; }
    }
    public class ClientContacts
    {
        [JsonProperty("15")]
        [JsonPropertyName("15")]
        public string _15 { get; set; }

        [JsonProperty("16")]
        [JsonPropertyName("16")]
        public string _16 { get; set; }
    }
    public class ContactClientCustomFields
    {
        [JsonProperty("contacts")]
        [JsonPropertyName("contacts")]
        public ClientContacts Contacts { get; set; }
    }
    public class ContactClient
    {
        [JsonProperty("firstname")]
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("patronymic")]
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("profile_image")]
        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("phonenumber")]
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("gender")]
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonProperty("birthday")]
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("password")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonProperty("is_primary")]
        [JsonPropertyName("is_primary")]
        public string IsPrimary { get; set; }

        [JsonProperty("active")]
        [JsonPropertyName("active")]
        public string Active { get; set; }

        [JsonProperty("donotsendwelcomeemail")]
        [JsonPropertyName("donotsendwelcomeemail")]
        public string Donotsendwelcomeemail { get; set; }

        [JsonProperty("permissions")]
        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("invoice_emails")]
        [JsonPropertyName("invoice_emails")]
        public string InvoiceEmails { get; set; }

        [JsonProperty("project_emails")]
        [JsonPropertyName("project_emails")]
        public string ProjectEmails { get; set; }

        [JsonProperty("ticket_emails")]
        [JsonPropertyName("ticket_emails")]
        public string TicketEmails { get; set; }

        [JsonProperty("task_emails")]
        [JsonPropertyName("task_emails")]
        public string TaskEmails { get; set; }

        [JsonProperty("contract_emails")]
        [JsonPropertyName("contract_emails")]
        public string ContractEmails { get; set; }

        [JsonProperty("proposal_emails")]
        [JsonPropertyName("proposal_emails")]
        public string ProposalEmails { get; set; }

        [JsonProperty("custom_fields")]
        [JsonPropertyName("custom_fields")]
        public ContactClientCustomFields CustomFields { get; set; }
    }

}
