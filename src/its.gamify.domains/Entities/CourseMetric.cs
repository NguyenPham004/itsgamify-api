namespace its.gamify.domains.Entities
{
    public class CourseMetric : BaseEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = default!;
        public int SaveCount { get; set; } = 0;
        public int CompletionCount { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
        public double StarRating { get; set; } = 0;
    }
}
