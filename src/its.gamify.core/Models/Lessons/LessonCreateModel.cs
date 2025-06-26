using its.gamify.core.Models.Files;
using its.gamify.domains.Enums;
using Newtonsoft.Json;

namespace its.gamify.core.Models.Lessons
{
    public class LessonCreateModel
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        public FileUploadRequestModel? File { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public string Type { get; set; } = LearningMaterialType.Video.ToString();
    }
}
