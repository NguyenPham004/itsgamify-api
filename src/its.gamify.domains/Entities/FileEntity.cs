namespace its.gamify.domains.Entities
{
    public class FileEntity : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Extension
        { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
