using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestApi.Perfectum
{
    public class ClientToConvertDatum
    {
        [JsonProperty("userid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("userid")]
        public string Userid { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonProperty("vat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("vat")]
        public object Vat { get; set; }

        [JsonProperty("phonenumber", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonProperty("datecreated", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("datecreated")]
        public string Datecreated { get; set; }

        [JsonProperty("dateupdated", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("dateupdated")]
        public string Dateupdated { get; set; }

        [JsonProperty("date_status_changed", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date_status_changed")]
        public object DateStatusChanged { get; set; }

        [JsonProperty("billing_street", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing_street")]
        public object BillingStreet { get; set; }

        [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing_city")]
        public object BillingCity { get; set; }

        [JsonProperty("billing_state", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing_state")]
        public object BillingState { get; set; }

        [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing_zip")]
        public object BillingZip { get; set; }

        [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("shipping_street", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shipping_street")]
        public object ShippingStreet { get; set; }

        [JsonProperty("shipping_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shipping_city")]
        public object ShippingCity { get; set; }

        [JsonProperty("shipping_state", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shipping_state")]
        public object ShippingState { get; set; }

        [JsonProperty("shipping_zip", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shipping_zip")]
        public object ShippingZip { get; set; }

        [JsonProperty("shipping_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shipping_country")]
        public string ShippingCountry { get; set; }

        [JsonProperty("default_language", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("default_language")]
        public string DefaultLanguage { get; set; }

        [JsonProperty("default_currency", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonProperty("discount_group", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("discount_group")]
        public string DiscountGroup { get; set; }

        [JsonProperty("is_provider", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_provider")]
        public string IsProvider { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("groups_in", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("groups_in")]
        public List<string> GroupsIn { get; set; }

        [JsonProperty("contacts_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts_id")]
        public List<string> ContactsId { get; set; }

        [JsonProperty("customer_admins", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("customer_admins")]
        public List<string> CustomerAdmins { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("custom_fields")]
        public List<object> CustomFields { get; set; }
    }

    public class ClientToConvert
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<ClientToConvertDatum> Data { get; set; }
    }


}
