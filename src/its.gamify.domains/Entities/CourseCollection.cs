namespace its.gamify.domains.Entities;

public class CourseCollection : BaseEntity
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}