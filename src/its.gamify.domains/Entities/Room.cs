using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities
{
    public class Room : BaseEntity
    {
        public int QuestionCount { get; set; }
        public int TimePerQuestion { get; set; }
        public int BetPoints { get; set; }
        public Guid ChallengeId { get; set; }
        public Challenge Challenge { get; set; } = null!;
        public string Status { get; set; } = ROOM_STATUS.WAITING;
        public Guid? HostUserId { get; set; }
        public User? HostUser { get; set; }
        public Guid? OpponentUserId { get; set; }
        public User? OpponentUser { get; set; }
        public int HostScore { get; set; } = 0;
        public int OpponentScore { get; set; } = 0;
        public bool IsHostReady { get; set; } = false;
        public bool IsOpponentReady { get; set; } = false;
        public bool IsHostAnswer { get; set; } = false;
        public bool IsOpponentAnswer { get; set; } = false;
        public int CurrentQuestion { get; set; } = 0;
    }
}
