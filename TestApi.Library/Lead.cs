using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class DatumLead
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("owner")]
        public int Owner { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("changed_by")]
        public string ChangedBy { get; set; }

        [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("converted")]
        public bool Converted { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonProperty("patronymic", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_source")]
        public string UtmSource { get; set; }

        [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_medium")]
        public string UtmMedium { get; set; }

        [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_campaign")]
        public string UtmCampaign { get; set; }

        [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_content")]
        public string UtmContent { get; set; }

        [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_term")]
        public string UtmTerm { get; set; }

        [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messengers")]
        public string Messengers { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<PhoneLead> Phone { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<SourceLead> Source { get; set; }

        [JsonProperty("lead_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lead_label")]
        public List<LeadLabel> LeadLabel { get; set; }

        [JsonProperty("kanban_status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_status")]
        public string KanbanStatus { get; set; }

        [JsonProperty("kanban_reason_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_reason_id")]
        public string KanbanReasonId { get; set; }

        [JsonProperty("uf_crm_lead_1677153916230", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_lead_1677153916230")]
        public string UfCrmLead1677153916230 { get; set; }

        [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_city")]
        public string AddressCity { get; set; }

        [JsonProperty("birthdate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source_description")]
        public string SourceDescription { get; set; }

        [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country")]
        public string AddressCountry { get; set; }

        [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_region")]
        public string AddressRegion { get; set; }

        [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_postal_code")]
        public string AddressPostalCode { get; set; }

        [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_province")]
        public string AddressProvince { get; set; }

        [JsonProperty("address_country_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country_code")]
        public string AddressCountryCode { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_stage_id")]
        public int KanbanStageId { get; set; }
    }
    public class LeadLabel
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sort")]
        public string Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
    public class LinkLead
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonProperty("last", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("last")]
        public string Last { get; set; }

        [JsonProperty("prev", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("prev")]
        public object Prev { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("next")]
        public string Next { get; set; }
    }
    public class MetaLead
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

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public List<LinkLead> Links { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("path")]
        public string Path { get; set; }

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
    public class PhoneLead
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

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sort")]
        public string Sort { get; set; }
    }
    public class Lead
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumLead> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public LinkLead Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public MetaLead Meta { get; set; }
    }
    public class SourceLead
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sort")]
        public object Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
}
