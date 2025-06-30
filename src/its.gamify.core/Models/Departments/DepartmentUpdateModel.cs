using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Departments
{
    public class DepartmentUpdateModel : DepartmentCreateModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
