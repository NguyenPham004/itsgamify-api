namespace its.gamify.domains.Entities;

public class RoomUser : BaseEntity
{

    public Guid RoomId { get; set; }
    public virtual Room Room { get; set; } = null!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public bool IsOutRoom { get; set; }
    public int CurrentScore { get; set; }
    public int CorrectAnswers { get; set; }
    public bool IsCurrentQuestionAnswered { get; set; }
}