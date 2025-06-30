namespace its.gamify.core.Models.Courses
{
    public class CourseUpdateModel : CourseCreateModels
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
    }
}
