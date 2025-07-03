using System.Text.Json.Serialization;
using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities;

public class LearningMaterial : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("course_id")]
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!; // Navigation property to the course this material belongs to
    [JsonPropertyName("file_id")]
    public Guid FileId { get; set; }
    public virtual FileEntity? File { get; set; }

}