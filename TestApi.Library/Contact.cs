using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class Comp 
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<PhoneCompany>? Phone { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Emails>? Email { get; set; }
    }
    public class ContactLabel
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
    public class DatumContact
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
        public object ChangedBy { get; set; }

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

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("companies")]
        public List<Comp> Companies { get; set; }

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
        public List<PhoneCompany> Phone { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Emails> Email { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<SourceContact> Source { get; set; }

        [JsonProperty("contact_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contact_label")]
        public List<ContactLabel> ContactLabel { get; set; }

        [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_city")]
        public string AddressCity { get; set; }

        [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("uf_crm_1633092405601", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633092405601")]
        public string UfCrm1633092405601 { get; set; }

        [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_province")]
        public string AddressProvince { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_region")]
        public string AddressRegion { get; set; }

        [JsonProperty("birthdate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("post", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("post")]
        public string Post { get; set; }

        [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country")]
        public string AddressCountry { get; set; }

        [JsonProperty("address_loc_addr_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_loc_addr_id")]
        public string AddressLocAddrId { get; set; }

        [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source_description")]
        public string SourceDescription { get; set; }

        [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_postal_code")]
        public string AddressPostalCode { get; set; }

        [JsonProperty("address_country_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country_code")]
        public string AddressCountryCode { get; set; }

        [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_stage_id")]
        public string KanbanStageId { get; set; }
    }
    public class LinkContact
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
    public class MetaContact
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
        public List<LinkContact> Links { get; set; }

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
    public class Contact
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumContact> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public LinkContact Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public MetaContact Meta { get; set; }
    }
    public class SourceContact
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
