using its.gamify.domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.QuizAnswers
{
    public class QuizAnswerCreateModel
    {
        public string Answer { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Guid QuizResultId { get; set; }
    }
}
