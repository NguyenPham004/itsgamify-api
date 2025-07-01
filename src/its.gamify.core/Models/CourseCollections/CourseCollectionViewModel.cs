using its.gamify.core.Models.Courses;

namespace its.gamify.core.Models.CourseCollections
{
    public class CourseCollectionViewModel : CourseCollectionUpdateModel
    {
        public CourseViewModel CourseViewModel { get; set; } = new();
    }
}
