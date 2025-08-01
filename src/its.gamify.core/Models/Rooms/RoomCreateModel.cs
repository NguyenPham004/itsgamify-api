namespace its.gamify.core.Models.Rooms
{
    public class RoomCreateModel
    {
        public int QuestionCount { get; set; }
        public int TimePerQuestion { get; set; }
        public int BetPoints { get; set; }
        public Guid ChallengeId { get; set; }
        public Guid? HostUserId { get; set; }
    }
}
