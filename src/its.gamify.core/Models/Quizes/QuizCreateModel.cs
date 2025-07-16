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
        public double TotalMark { get; set; } = 0.0;
        public double PassedMark { get; set; } = 0.0;
        public int TotalQuestion { get; set; } = 0;
        public Guid LessonId { get; set; }
        public Guid ChallengIdId { get; set; }
    }
}
