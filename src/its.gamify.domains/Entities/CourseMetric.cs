namespace its.gamify.domains.Entities
{
    public class CourseMetric:BaseEntity
    {
        public Guid CourseId { get; set; }
        public int SaveCount { get; set; } = 0;
        public int CompletionCount { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
        public double StartRating { get; set; } = 0;    
    }
}
