using its.gamify.core.Models.Files;
using its.gamify.domains.Enums;

namespace its.gamify.core.Models.Courses
{
    public class CourseCreateModel
    {
        public string Title { get; set; } = string.Empty;
        public double DurationInHours { get; set; } = 0.0;
        public CourseTypeEnum CourseType { get; set; } = CourseTypeEnum.All;
        public string Description { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public FileUploadRequestModel? ThumbNail { get; set; }
        public FileUploadRequestModel? IntroVideo { get; set; }
        public List<string> Tags { get; set; } = new();
        public Guid QuarterId { get; set; }
        public Guid DifficultyLevelId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
