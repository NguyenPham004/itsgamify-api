using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.QuizResults
{
    public class QuizResultCreateModel
    {
        public double Score { get; set; } = 0.0;
        public DateTime CompletedDate { get; set; } = DateTime.Now;
        public bool IsPassed { get; set; } = false;
        public Guid LearningProgressId { get; set; }
    }
}
