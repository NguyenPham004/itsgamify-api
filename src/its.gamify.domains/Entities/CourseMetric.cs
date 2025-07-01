namespace its.gamify.domains.Entities
{
    public class CourseMetric:BaseEntity
    {
        public Guid CourseId { get; set; }
        public int SaveCount { get; set; }
        public int CompletionCount { get; set; }
        public int ReviewCount { get; set;}
        public double StartRating { get; set; } 
    }
}
