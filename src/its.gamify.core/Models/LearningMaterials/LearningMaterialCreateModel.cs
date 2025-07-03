using System.Text.Json.Serialization;
using its.gamify.core.Models.Files;
using its.gamify.domains.Enums;
using Microsoft.AspNetCore.Http;

namespace its.gamify.core.Models.LearningMaterials
{
    public class LearningMaterialCreateModel
    {
        public required IFormFile File { get; set; }
        [JsonPropertyName("course_id")]
        public Guid CourseId { get; set; }
    }
}
