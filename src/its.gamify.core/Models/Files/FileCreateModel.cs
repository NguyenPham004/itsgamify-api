using Microsoft.AspNetCore.Http;

namespace its.gamify.core.Models.Files
{
    public class FileCreateModel
    {
        public required IFormFile File { get; set; }
    }
}
