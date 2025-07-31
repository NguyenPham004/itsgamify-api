namespace its.gamify.domains.Entities
{
    public class Room : BaseEntity
    {
        public int AmountQuestion { get; set; }
        public int TimeQuestion { get; set; }
        public float BetPoint { get; set; }
        public Guid ChallengeId { get; set; }
        public Challenge Challenge { get; set; } = null!;
    }
}
