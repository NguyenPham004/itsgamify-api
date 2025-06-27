using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Files
{
    public class FileUploadResponseModel
    {
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string FileName { get; set; } = string.Empty;
    }
    public class FileResponseModel : FileUploadResponseModel
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}
