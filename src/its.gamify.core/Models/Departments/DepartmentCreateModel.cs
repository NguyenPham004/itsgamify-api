using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Departments
{
    public class DepartmentCreateModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
    }
}
