namespace its.gamify.domains.Entities;

public class Quiz : BaseEntity
{
    public double TotalMark { get; set; } = 0.0;
    public double PassedMark { get; set; } = 0.0;
    public int TotalQuestions { get; set; } = 0;
    public double Duration { get; set; } = 0;
    public virtual ICollection<Question> Questions { get; set; } = [];
    public virtual ICollection<QuizResult> QuizResults { get; set; } = [];
    public Guid? ChallengeId { get; set; }
    public virtual Challenge? Challenge { get; set; } = null!;
}