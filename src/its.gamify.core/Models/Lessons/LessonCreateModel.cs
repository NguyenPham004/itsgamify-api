
using its.gamify.core.Models.Practices;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Lessons;

public class LessonCreateModel
{

    public string Title { get; set; } = string.Empty;
    public int Index { get; set; }
    [JsonPropertyName("duration")]
    public double DurationInMinutes { get; set; }
    public string Type { get; set; } = LearningMaterialType.VIDEO.ToString();
    public string? Content { get; set; }
    [JsonPropertyName("module_id")]
    public Guid? CourseSectionId { get; set; }
    public List<FileEntity>? ImageFiles { get; set; }
}

public class LessonUpdateModel : LessonCreateModel
{
    public Guid Id { get; set; }
    [JsonPropertyName("video_url")]
    public string? Url { get; set; } = string.Empty;
    [JsonPropertyName("quiz_id")]
    public Guid? QuizId { get; set; }
    [JsonPropertyName("questions")]
    public List<QuestionUpsertModel>? QuestionModels { get; set; }

    [JsonPropertyName("practices")]
    public List<PracticeUpsertModel>? Practices { get; set; }

}

public class LearningProgessUpsertModel
{
    public Guid LessonId { get; set; }
    public double VideoTimePosition { get; set; } = 0;
    public string? Type { get; set; } = LearningMaterialType.VIDEO.ToString();
    public string Status { get; set; } = PROGRESS_STATUS.IN_PROGRESS;
    public Guid CourseParticipationId { get; set; }
}