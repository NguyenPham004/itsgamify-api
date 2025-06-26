using System.Text.Json.Serialization;

namespace its.gamify.domains.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    [JsonPropertyName("updated_date")]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; } = false;
    [JsonPropertyName("created_by")]
    public Guid CreatedBy { get; set; } = Guid.Empty;
    [JsonPropertyName("updated_by")]
    public Guid UpdatedBy { get; set; } = Guid.Empty;
}