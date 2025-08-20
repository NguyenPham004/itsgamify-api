using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities
{
    public class UserChallengeHistory : BaseEntity
    {
        public int YourScore { get; set; } = 0;
        public int WinnerScore { get; set; } = 0;
        public string Status { get; set; } = UserChallengeHistoryEnum.WIN;
        public int Rank { get; set; }
        public int Points { get; set; }
        public double AverageCorrect { get; set; }
        public Guid WinnerId { get; set; }
        public virtual User Winner { get; set; } = null!;
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public Guid ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; } = null!;
    }
}
