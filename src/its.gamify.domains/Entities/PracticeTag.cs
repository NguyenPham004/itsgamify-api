namespace its.gamify.domains.Entities;

public class PracticeTag : BaseEntity
{
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;

    public Guid? LessonId { get; set; }
    public virtual Lesson? Lesson { get; set; }

}