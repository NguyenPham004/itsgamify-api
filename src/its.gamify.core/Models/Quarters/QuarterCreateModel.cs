namespace its.gamify.core.Models.Quarters
{
    public class QuarterCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
