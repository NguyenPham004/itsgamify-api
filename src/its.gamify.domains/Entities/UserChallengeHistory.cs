using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities
{
    public class UserChallengeHistory : BaseEntity
    {
        public int YourScore { get; set; } = 0;
        public int OppScore { get; set; } = 0;
        public string Status { get; set; } = UserChallengeHistoryEnum.WIN;
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public Guid OpponentId { get; set; }
        public virtual User Opponent { get; set; } = null!;
        public Guid ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; } = null!;
    }
}
