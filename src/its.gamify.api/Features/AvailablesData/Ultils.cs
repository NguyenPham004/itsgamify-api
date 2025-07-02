using its.gamify.domains.Entities;

namespace its.gamify.core.Features.AvailablesData
{
    public static class UltilsFunction
    {
        public static List<T> PaginationFunction<T>(this List<T> source, int pageNumber = 0, int pageSize = 10)
        {
            if (source == null) return new List<T>();
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            return source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
    public class Ultils
    {
        public void AddList()
        {
            List<QuizAnswer> quizAnswers = new List<QuizAnswer>();
            for (int i = 0; i < 60; i++)
            {
                quizAnswers.Add(new QuizAnswer
                {
                    Id = Guid.NewGuid(),
                    Answer = $"Answer {((char)('A' + (i % 4))).ToString()}",
                    IsCorrect = (i % 2 == 0),
                    QuestionId = Guid.NewGuid(),
                    QuizResultId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = Guid.NewGuid(),
                    UpdatedBy = Guid.NewGuid()
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                leaderBoards.Add(new LeadearBoard
                {
                    Name = $"LeaderBoard {i}",
                    Description = $"Description for LeaderBoard {i}."
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                badges.Add(new Badge
                {
                    Name = $"Badge {i}",
                    Description = $"Description for Badge {i}.",
                    ClaimedDate = DateTime.Now.AddDays(-i), // Ngày được trao giảm dần
                    UserId = Guid.NewGuid(),
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                employeeMetrics.Add(new EmployeeMetric
                {
                    Description = $"Employee Metric for User {i}.",
                    UserId = Guid.NewGuid()
                });
            }
            for (int i = 1; i <= 10; i++)
            {
                notifications.Add(new Notification
                {
                    Title = $"Notification {i}",
                    Message = $"Message for Notification {i}.",
                    Precedence = i, // Độ ưu tiên tăng dần
                    UserId = Guid.NewGuid()
                });
            }

        }
        private readonly string _filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Feature", "AvailableData.json");
        public List<Quarter> quarters;
        public List<QuizResult> quizResults;
        public List<Quiz> quizzes;
        public List<Question> questions;
        public List<Course> courses;
        public List<Department> departments;
        public List<Category> categories;
        public List<LeadearBoard> leaderBoards = new List<LeadearBoard>();
        public List<Badge> badges = new List<Badge>();
        public List<EmployeeMetric> employeeMetrics = new List<EmployeeMetric>();
        public List<Notification> notifications = new List<Notification>();
        public Ultils()
        {




            /* public async Task<List<Quarter>> GetAllQuarterssAsync()
             {
                 if (!File.Exists(_filePath))
                     return new List<Quarter>();

                 var json = await File.ReadAllTextAsync(_filePath);
                 var objectReadable = JsonSerializer.Deserialize<QuizData>(json);
                 var result = objectReadable?.quarters;
                 return result ?? new List<Quarter>();
             }*/
        }
        /*public class QuizData
        {
            public List<Quarter> quarters;
            public List<QuizAnswer> quizAnswers;
            public List<QuizResult> quizResults;
            public List<Quiz> quizzes;
            public List<Question> questions;
            public List<Course> courses;
            public List<Department> departments;
        }*/
    }
}
