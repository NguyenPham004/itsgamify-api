using its.gamify.domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.Quizes
{
    public class QuizCreateModel
    {
        public double TotalMarks { get; set; } = 0.0;
        public double PassedMarks { get; set; } = 0.0;
        public int TotalQuestions { get; set; } = 0;
        public Guid LessonId { get; set; }
        public Guid ChallengIdId { get; set; }
    }
}
