namespace its.gamify.domains.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public ICollection<User>? Users { get; set; }
    // public ICollection<Course>? Courses { get; set; }
    public ICollection<Course>? Courses { get; set; }
    public virtual ICollection<CourseDepartment> CourseDepartments { get; set; } = [];


}