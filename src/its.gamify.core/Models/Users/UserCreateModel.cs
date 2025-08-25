using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Users
{
    public class UserCreateModel
    {
        public string FullName { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string? Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; } = Guid.Empty;
        public Guid RoleId { get; set; } = Guid.Empty;

    }
}
