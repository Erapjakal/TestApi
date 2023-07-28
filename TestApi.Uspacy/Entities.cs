using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestApi.Uspacy
{
    #region Entity

    #endregion
    public class Entity
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("tableName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tableName")]
        public string TableName { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sort")]
        public int Sort { get; set; }
    }
    public class Meta
    {
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("list")]
        public int List { get; set; }
    }
    public class Entities
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<Entity> Data { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
    public class DatumField
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("db_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("db_type")]
        public string DbType { get; set; }

        [JsonProperty("multiple", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("multiple")]
        public int Multiple { get; set; }
    }
    public class FieldType
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<DatumField> Data { get; set; }
    }
    #region Entity items list
    public class Datum
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("owner")]
        public int Owner { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messengers")]
        public List<Messenger> Messengers { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("changed_by")]
        public int ChangedBy { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }
    }
    public class Email
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
    }
    public class Messenger
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
    public class Phone
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
    }
    public class Root
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    #endregion

    #region Comments
    public class CommentDatum
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("entityType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("entityType")]
        public string EntityType { get; set; }

        [JsonProperty("entityId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("entityId")]
        public int EntityId { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonProperty("authorId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("authorId")]
        public int AuthorId { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonProperty("reactions", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("reactions")]
        public List<Reaction> Reactions { get; set; }

        [JsonProperty("nextId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("nextId")]
        public int NextId { get; set; }

        [JsonProperty("prevId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("prevId")]
        public int PrevId { get; set; }
    }

    public class Reaction
    {
        [JsonProperty("reaction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("reaction")]
        public int ReactionComment { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonProperty("entityId", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("entityId")]
        public int EntityId { get; set; }
    }
    public class Comments
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<CommentDatum> Data { get; set; }
    }

    #endregion

    #region Company
    public class CompanyDatum
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("owner")]
        public int Owner { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("messengers", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("messengers")]
        public List<Messenger> Messengers { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("changed_by", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("changed_by")]
        public int ChangedBy { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }
    }
    public class Company
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public List<CompanyDatum> Data { get; set; }

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
    #endregion
}
