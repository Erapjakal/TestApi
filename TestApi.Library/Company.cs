using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class CompanyLabel
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
        public int Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
    public class Contacts 
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<PhoneCompany> Phone { get; set; }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Emails> Email { get; set; }
    }
    public class Emails 
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
    public class DatumCompany
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
        public int ChangedBy { get; set; }

        [JsonProperty("converted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("converted")]
        public bool Converted { get; set; }

        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

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
        public List<string> Messengers { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<PhoneCompany> Phone { get; set; }

        //[JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Emails>? Email { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<SourceCompany> Source { get; set; }

        [JsonProperty("company_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_label")]
        public List<CompanyLabel> CompanyLabel { get; set; }

        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("site")]
        public string Site { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public List<Contacts> Contacts { get; set; }

        [JsonProperty("industry_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("industry_label")]
        public List<IndustryLabelCompany> IndustryLabel { get; set; }

        [JsonProperty("employees_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("employees_label")]
        public List<EmployeesLabelCompany> EmployeesLabel { get; set; }

        [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country")]
        public string AddressCountry { get; set; }

        [JsonProperty("uf_crm_1633094809449", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094809449")]
        public string UfCrm1633094809449 { get; set; }

        [JsonProperty("uf_crm_64059cccb9a0d", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_64059cccb9a0d")]
        public string UfCrm64059cccb9a0d { get; set; }

        [JsonProperty("uf_crm_1633095020302", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633095020302")]
        public string UfCrm1633095020302 { get; set; }

        [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_region")]
        public string AddressRegion { get; set; }

        [JsonProperty("uf_crm_1633094830259", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094830259")]
        public string UfCrm1633094830259 { get; set; }

        [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_city")]
        public string AddressCity { get; set; }

        [JsonProperty("uf_crm_1632917200758", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1632917200758")]
        public string UfCrm1632917200758 { get; set; }

        [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_2")]
        public string Address2 { get; set; }

        [JsonProperty("uf_crm_1633094879095", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094879095")]
        public string UfCrm1633094879095 { get; set; }

        [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_province")]
        public string AddressProvince { get; set; }

        [JsonProperty("uf_crm_1633094857441", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094857441")]
        public string UfCrm1633094857441 { get; set; }

        [JsonProperty("uf_crm_1633094958676", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094958676")]
        public string UfCrm1633094958676 { get; set; }

        [JsonProperty("uf_crm_1633094913297", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094913297")]
        public string UfCrm1633094913297 { get; set; }

        [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_postal_code")]
        public string AddressPostalCode { get; set; }

        [JsonProperty("uf_crm_1633094896324", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094896324")]
        public string UfCrm1633094896324 { get; set; }

        [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_stage_id")]
        public string KanbanStageId { get; set; }
    }
    public class EmployeesLabelCompany
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
        public int Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
    public class IndustryLabelCompany
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
        public int Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
    public class LinkCompany
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
        public string Prev { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("next")]
        public string Next { get; set; }
    }
    public class MetaCompany
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
        public List<LinkCompany> Links { get; set; }

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
    public class PhoneCompany
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
    public class Company
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumCompany> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public LinkCompany Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public MetaCompany Meta { get; set; }
    }
    public class SourceCompany
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
        public int Sort { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }

}
