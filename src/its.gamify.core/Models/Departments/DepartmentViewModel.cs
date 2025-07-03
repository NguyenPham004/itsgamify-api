using its.gamify.domains.Entities;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Departments
{
    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;
        [JsonPropertyName("leader")]
        public User? Leader { get; set; }
        [JsonPropertyName("employee_count")]
        public int EmployeeCount { get; set; }
        [JsonPropertyName("course_count")]
        public int CourseCount { get; set; }
    }
}
