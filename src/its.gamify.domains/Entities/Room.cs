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
        public bool IsHostReady { get; set; } = false;
        public bool IsOpponentReady { get; set; } = false;
        public bool IsAbandoned { get; set; } = false;
    }
}
