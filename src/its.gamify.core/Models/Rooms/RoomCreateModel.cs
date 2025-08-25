namespace its.gamify.core.Models.Rooms
{
    public class RoomCreateModel
    {
        public required string Name { get; set; }
        public int QuestionCount { get; set; }
        public int TimePerQuestion { get; set; }
        public int BetPoints { get; set; }
        public Guid ChallengeId { get; set; }
        public Guid HostUserId { get; set; }
        public int MaxPlayers { get; set; } = 10;

    }

    public class JoinRoomModel
    {
        public string RoomCode { get; set; } = null!;

    }
}
