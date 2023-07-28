using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class TaskCompany
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
        public int Converted { get; set; }

        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_source")]
        public object UtmSource { get; set; }

        [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_medium")]
        public object UtmMedium { get; set; }

        [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_campaign")]
        public object UtmCampaign { get; set; }

        [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_content")]
        public object UtmContent { get; set; }

        [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_term")]
        public object UtmTerm { get; set; }

        [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messengers")]
        public object Messengers { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public object Phone { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public object Email { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<TaskSource> Source { get; set; }

        [JsonProperty("company_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_label")]
        public List<TaskCompanyLabel> CompanyLabel { get; set; }

        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("site")]
        public object Site { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public object Address { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public object Contacts { get; set; }

        [JsonProperty("industry_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("industry_label")]
        public List<TaskIndustryLabel> IndustryLabel { get; set; }

        [JsonProperty("employees_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("employees_label")]
        public List<TaskEmployeesLabel> EmployeesLabel { get; set; }

        [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country")]
        public object AddressCountry { get; set; }

        [JsonProperty("uf_crm_1633094809449", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094809449")]
        public object UfCrm1633094809449 { get; set; }

        [JsonProperty("uf_crm_64059cccb9a0d", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_64059cccb9a0d")]
        public object UfCrm64059cccb9a0d { get; set; }

        [JsonProperty("uf_crm_1633095020302", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633095020302")]
        public object UfCrm1633095020302 { get; set; }

        [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_region")]
        public object AddressRegion { get; set; }

        [JsonProperty("uf_crm_1633094830259", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094830259")]
        public object UfCrm1633094830259 { get; set; }

        [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_city")]
        public object AddressCity { get; set; }

        [JsonProperty("uf_crm_1632917200758", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1632917200758")]
        public string UfCrm1632917200758 { get; set; }

        [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_2")]
        public object Address2 { get; set; }

        [JsonProperty("uf_crm_1633094879095", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094879095")]
        public object UfCrm1633094879095 { get; set; }

        [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_province")]
        public object AddressProvince { get; set; }

        [JsonProperty("uf_crm_1633094857441", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094857441")]
        public object UfCrm1633094857441 { get; set; }

        [JsonProperty("uf_crm_1633094958676", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094958676")]
        public object UfCrm1633094958676 { get; set; }

        [JsonProperty("uf_crm_1633094913297", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094913297")]
        public object UfCrm1633094913297 { get; set; }

        [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_postal_code")]
        public object AddressPostalCode { get; set; }

        [JsonProperty("uf_crm_1633094896324", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633094896324")]
        public object UfCrm1633094896324 { get; set; }
    }
    public class TaskCompanyLabel
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
    public class TaskContact
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
        public int Converted { get; set; }

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
        public object Companies { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("position")]
        public object Position { get; set; }

        [JsonProperty("utm_source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_source")]
        public object UtmSource { get; set; }

        [JsonProperty("utm_medium", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_medium")]
        public object UtmMedium { get; set; }

        [JsonProperty("utm_campaign", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_campaign")]
        public object UtmCampaign { get; set; }

        [JsonProperty("utm_content", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_content")]
        public object UtmContent { get; set; }

        [JsonProperty("utm_term", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("utm_term")]
        public object UtmTerm { get; set; }

        [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messengers")]
        public object Messengers { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public object Phone { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public object Email { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<TaskSource> Source { get; set; }

        [JsonProperty("contact_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contact_label")]
        public List<TaskContactLabel> ContactLabel { get; set; }

        [JsonProperty("address_city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_city")]
        public object AddressCity { get; set; }

        [JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_2")]
        public object Address2 { get; set; }

        [JsonProperty("uf_crm_1633092405601", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633092405601")]
        public string UfCrm1633092405601 { get; set; }

        [JsonProperty("address_province", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_province")]
        public object AddressProvince { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address")]
        public object Address { get; set; }

        [JsonProperty("address_region", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_region")]
        public object AddressRegion { get; set; }

        [JsonProperty("birthdate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("birthdate")]
        public object Birthdate { get; set; }

        [JsonProperty("post", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("post")]
        public object Post { get; set; }

        [JsonProperty("address_country", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country")]
        public object AddressCountry { get; set; }

        [JsonProperty("address_loc_addr_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_loc_addr_id")]
        public object AddressLocAddrId { get; set; }

        [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source_description")]
        public string SourceDescription { get; set; }

        [JsonProperty("address_postal_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_postal_code")]
        public object AddressPostalCode { get; set; }

        [JsonProperty("address_country_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("address_country_code")]
        public object AddressCountryCode { get; set; }
    }
    public class TaskContactLabel
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
    public class TaskDatum
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public object Description { get; set; }

        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("start_time")]
        public int StartTime { get; set; }

        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("end_time")]
        public int EndTime { get; set; }

        [JsonProperty("responsible_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("responsible_id")]
        public int ResponsibleId { get; set; }

        [JsonProperty("company_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_id")]
        public int? CompanyId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company")]
        public TaskCompany Company { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public List<TaskContact> Contacts { get; set; }
    }
    public class TaskEmployeesLabel
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
    public class TaskIndustryLabel
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
    public class TaskLink
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
    public class TaskMeta
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
        public List<TaskLink> Links { get; set; }

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
    public class TaskRoot
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<TaskDatum> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public TaskLink Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public TaskMeta Meta { get; set; }
    }
    public class TaskSource
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
