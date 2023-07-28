using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class DatumDeal
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

        [JsonProperty("amount_of_the_deal", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("amount_of_the_deal")]
        public object AmountOfTheDeal { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public object Contacts { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("companies")]
        public object Companies { get; set; }

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

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("comments")]
        public string Comments { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public List<SourceDeal> Source { get; set; }

        [JsonProperty("deal_label", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deal_label")]
        public List<DealLabel> DealLabel { get; set; }

        [JsonProperty("kanban_status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_status")]
        public string KanbanStatus { get; set; }

        [JsonProperty("kanban_reason_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_reason_id")]
        public string KanbanReasonId { get; set; }

        [JsonProperty("uf_crm_1635844186", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1635844186")]
        public object UfCrm1635844186 { get; set; }

        [JsonProperty("uf_crm_1643976907290", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1643976907290")]
        public List<UfCrm1643976907290> UfCrm1643976907290 { get; set; }

        [JsonProperty("uf_crm_1633366687", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633366687")]
        public string UfCrm1633366687 { get; set; }

        [JsonProperty("uf_crm_1633430326", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633430326")]
        public object UfCrm1633430326 { get; set; }

        [JsonProperty("uf_crm_1635613706", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1635613706")]
        public bool UfCrm1635613706 { get; set; }

        [JsonProperty("probability", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("probability")]
        public object Probability { get; set; }

        [JsonProperty("uf_crm_1633366883", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633366883")]
        public object UfCrm1633366883 { get; set; }

        [JsonProperty("uf_crm_1682054017546", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1682054017546")]
        public object UfCrm1682054017546 { get; set; }

        [JsonProperty("uf_crm_1633429677", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633429677")]
        public object UfCrm1633429677 { get; set; }

        [JsonProperty("additional_info", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("additional_info")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("uf_crm_1633367478", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633367478")]
        public string UfCrm1633367478 { get; set; }

        [JsonProperty("uf_crm_1633366948", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633366948")]
        public string UfCrm1633366948 { get; set; }

        [JsonProperty("uf_crm_1633635449", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633635449")]
        public string UfCrm1633635449 { get; set; }

        [JsonProperty("uf_crm_1638006384173", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1638006384173")]
        public string UfCrm1638006384173 { get; set; }

        [JsonProperty("uf_crm_1633366773", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633366773")]
        public string UfCrm1633366773 { get; set; }

        [JsonProperty("uf_crm_1633367088", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633367088")]
        public string UfCrm1633367088 { get; set; }

        [JsonProperty("uf_crm_1633374013", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633374013")]
        public bool UfCrm1633374013 { get; set; }

        [JsonProperty("source_description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source_description")]
        public string SourceDescription { get; set; }

        [JsonProperty("uf_crm_1633367397", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633367397")]
        public string UfCrm1633367397 { get; set; }

        [JsonProperty("uf_crm_1635799855", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1635799855")]
        public string UfCrm1635799855 { get; set; }

        [JsonProperty("uf_crm_1633366980", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633366980")]
        public object UfCrm1633366980 { get; set; }

        [JsonProperty("uf_crm_1633429703", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633429703")]
        public object UfCrm1633429703 { get; set; }

        [JsonProperty("uf_crm_1633373781", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("uf_crm_1633373781")]
        public string UfCrm1633373781 { get; set; }

        [JsonProperty("kanban_stage_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("kanban_stage_id")]
        public int KanbanStageId { get; set; }
    }
    public class DealLabel
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
    public class LinkDeal
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
    public class MetaDeal
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
        public List<LinkDeal> Links { get; set; }

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
    public class Deal
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumDeal> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public LinkDeal Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public MetaDeal Meta { get; set; }
    }
    public class SourceDeal
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
    public class UfCrm1643976907290
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
}
