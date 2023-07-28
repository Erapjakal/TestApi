using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Library
{
    public class CompanyCall
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
    public class DatumCall
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("task_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("task_id")]
        public int? TaskId { get; set; }

        [JsonProperty("contact_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contact_id")]
        public object ContactId { get; set; }

        [JsonProperty("company_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("company_id")]
        public int? CompanyId { get; set; }

        [JsonProperty("deal_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deal_id")]
        public object DealId { get; set; }

        [JsonProperty("lead_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lead_id")]
        public int? LeadId { get; set; }

        [JsonProperty("entity_table", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("entity_table")]
        public string EntityTable { get; set; }

        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonProperty("call_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("call_type")]
        public string CallType { get; set; }

        [JsonProperty("ended_call_status", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ended_call_status")]
        public string EndedCallStatus { get; set; }

        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("begin_time")]
        public int BeginTime { get; set; }

        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("end_time")]
        public int? EndTime { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [JsonProperty("call_record_link", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("call_record_link")]
        public object CallRecordLink { get; set; }

        [JsonProperty("call_record_file", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("call_record_file")]
        public object CallRecordFile { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("note")]
        public object Note { get; set; }

        [JsonProperty("integration_code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("integration_code")]
        public string IntegrationCode { get; set; }

        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("tmp_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tmp_id")]
        public object TmpId { get; set; }

        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("contacts")]
        public List<object> Contacts { get; set; }

        [JsonProperty("companies", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("companies")]
        public List<CompanyCall> Companies { get; set; }

        [JsonProperty("employees", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("employees")]
        public List<int> Employees { get; set; }

        [JsonProperty("leads", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("leads")]
        public List<LeadCall> Leads { get; set; }

        [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tasks")]
        public Tasks Tasks { get; set; }
    }
    public class LeadCall
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
    public class LinkCall
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
    public class MetaCall
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
        public List<LinkCall> Links { get; set; }

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
    public class Call
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumCall> Data { get; set; }

        [JsonProperty("links", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("links")]
        public LinkCall Links { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public MetaCall Meta { get; set; }
    }
    public class Tasks
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
