using System.Text.Json.Serialization;

namespace its.gamify.core.Services;


public class CreateRoleModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}