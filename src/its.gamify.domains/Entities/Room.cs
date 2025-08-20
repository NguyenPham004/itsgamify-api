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
        public string RoomCode { get; set; } = null!;
        public int MaxPlayers { get; set; }
        public int CurrentQuestionIndex { get; set; } = 0;
        public Guid? CurrentQuestionId { get; set; }
        public Guid HostUserId { get; set; }
        public virtual User HostUser { get; set; } = null!;
        public virtual ICollection<RoomUser>? RoomUsers { get; set; } = null!;
    }
}
