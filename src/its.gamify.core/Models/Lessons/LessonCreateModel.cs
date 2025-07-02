using its.gamify.core.Models.Practices;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Enums;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Lessons
{
    public class LessonCreateModel
    {

        [JsonPropertyName("id")]
        public Guid? CreateId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Index { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("duration")]
        public int DurationInMinutes { get; set; }
        [JsonPropertyName("video_url")]
        public string? VideoUrl { get; set; } = string.Empty;
        public string Type { get; set; } = LearningMaterialType.VIDEO.ToString();
        [JsonPropertyName("quiz")]
        public List<QuestionUpsertModel>? QuestionModels { get; set; }

        [JsonPropertyName("practice")]
        public List<PracticeUpsertModel>? Practices { get; set; }
        public string? Content { get; set; }
    }
}
