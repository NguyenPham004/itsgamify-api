namespace its.gamify.domains.Entities;

public class EmployeeMetric : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public int CourseParticipatedNum { get; set; } = 0;
    public int CourseCompletedNum { get; set; } = 0;
    public int ChallengeParticipateNum { get; set; } = 0;
    public int ChallengeAwardNum { get; set; } = 0;
    public int PointInQuarter { get; set; } = 0;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public Guid QuarterId { get; set; }
    public virtual Quarter Quarter { get; set; } = null!;

}