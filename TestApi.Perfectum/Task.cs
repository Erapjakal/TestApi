using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Perfectum
{
    public class TaskCustomFields
    {
        [JsonProperty("tasks", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tasks")]
        public Tasks Tasks { get; set; }
    }
    public class Task
    {
        [JsonProperty("billable", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("billable")]
        public string Billable { get; set; }

        [JsonProperty("is_public", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("is_public")]
        public string IsPublic { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("startdate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("startdate")]
        public string Startdate { get; set; }

        [JsonProperty("duedate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("duedate")]
        public string Duedate { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("hourly_rate")]
        public string HourlyRate { get; set; }

        [JsonProperty("deadline_staff_active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deadline_staff_active")]
        public string DeadlineStaffActive { get; set; }

        [JsonProperty("deadline_staff", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deadline_staff")]
        public string DeadlineStaff { get; set; }

        [JsonProperty("staff_assignee", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("staff_assignee")]
        public List<string> StaffAssignee { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonProperty("rel_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rel_type")]
        public string RelType { get; set; }

        [JsonProperty("rel_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rel_id")]
        public string RelId { get; set; }

        [JsonProperty("staff_deadline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("staff_deadline")]
        public List<StaffDeadline> StaffDeadline { get; set; }

        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("custom_fields")]
        public TaskCustomFields CustomFields { get; set; }

        [JsonProperty("repeat_every", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("repeat_every")]
        public string RepeatEvery { get; set; }

        [JsonProperty("recurring", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("recurring")]
        public string Recurring { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
    public class StaffDeadline
    {
        [JsonProperty("staff_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("staff_id")]
        public string StaffId { get; set; }

        [JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("deadline")]
        public string Deadline { get; set; }
    }
    public class Tasks
    {
        [JsonProperty("79", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("79")]
        public string _79 { get; set; }
    }
}
