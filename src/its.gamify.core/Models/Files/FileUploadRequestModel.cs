using Microsoft.AspNetCore.Http;

namespace its.gamify.core.Models.Files
{
    public class FileUploadRequestModel
    {
        public IFormFile File { get; set; } = null;
        public string? Directory { get; set; }
    }
}
