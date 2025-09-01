using its.gamify.domains.Enums;
using System.Text.Json.Serialization;

namespace its.gamify.domains.Entities;

public class Lesson : BaseEntity
{
    public int Index { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    [JsonPropertyName("duration")]
    public double DurationInMinutes { get; set; }
    public string Type { get; set; } = LearningMaterialType.VIDEO.ToString(); // e.g., Video, Article, Quiz
    [JsonPropertyName("video_url")]
    public string? Url { get; set; } = string.Empty;
    public List<FileEntity>? ImageFiles { get; set; }


    [JsonPropertyName("practices")]
    public ICollection<PracticeTag> Practices { get; set; } = [];

    [JsonPropertyName("quiz_id")]
    public Guid? QuizId { get; set; }
    [JsonPropertyName("quiz")]
    public virtual Quiz? Quiz { get; set; }


    [JsonPropertyName("module_id")]
    public Guid? CourseSectionId { get; set; }
    public virtual CourseSection CourseSection { get; set; } = null!; // Navigation property to the course section this lesson belongs to
}