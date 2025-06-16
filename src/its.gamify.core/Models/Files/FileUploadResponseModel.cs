namespace its.gamify.core.Models.Files
{
    public class FileUploadResponseModel
    {
        public string Url { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
}
