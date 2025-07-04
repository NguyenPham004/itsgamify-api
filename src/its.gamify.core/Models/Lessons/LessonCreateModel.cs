
using its.gamify.core.Models.Questions;
using its.gamify.domains.Enums;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Lessons
{
    public class LessonCreateModel
    {

        public string Title { get; set; } = string.Empty;
        public int Index { get; set; }
        [JsonPropertyName("duration")]
        public int DurationInMinutes { get; set; }
        public string Type { get; set; } = LearningMaterialType.VIDEO.ToString();
        public string? Content { get; set; }
        [JsonPropertyName("module_id")]
        public Guid? CourseSectionId { get; set; }
    }

    public class LessonUpdateModel : LessonCreateModel
    {
        public Guid Id { get; set; }
        [JsonPropertyName("video_url")]
        public string? Url { get; set; } = string.Empty;
        [JsonPropertyName("quiz")]
        public List<QuestionUpsertModel>? QuestionModels { get; set; }

        // [JsonPropertyName("practice")]
        // public List<PracticeUpsertModel>? Practices { get; set; }

    }
}
