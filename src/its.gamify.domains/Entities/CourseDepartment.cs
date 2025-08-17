namespace its.gamify.domains.Entities
{
    public class CourseDepartment : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public Guid DepartmentId { get; set; }
        public Department Deparment { get; set; } = null!;
    }
}
