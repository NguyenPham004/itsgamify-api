using System.Text.Json.Serialization;
using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities;

public class LearningProgress : BaseEntity
{
    public string Status { get; set; } = PROGRESS_STATUS.IN_PROGRESS;
    public DateTime LastAccessed { get; set; } = DateTime.Now;
    public double? VideoTimePosition { get; set; } = 0.0;
    public Guid CourseParticipationId { get; set; }
    public virtual CourseParticipation CourseParticipation { get; set; } = null!;

    public Guid LessonId { get; set; }
    public virtual Lesson Lesson { get; set; } = default!;

    public Guid? QuizResultId { get; set; }
    public virtual QuizResult? QuizResult { get; set; } = null!;
}