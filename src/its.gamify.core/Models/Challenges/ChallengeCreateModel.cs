using its.gamify.core.Models.Questions;

namespace its.gamify.core.Models.Challenges
{
    public class ChallengeCreateModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumOfRoom { get; set; }
        public string ThumbnailImage { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public Guid ThumbnailImageId { get; set; }
        public Guid CategoryId { get; set; }

        public List<QuestionUpdateModel> UpdatedQuestions { get; set; } = [];
        public List<QuestionUpdateModel> NewQuestions { get; set; } = [];
    }
}
