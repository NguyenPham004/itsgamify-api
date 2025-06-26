using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.QuizAnswers
{
    public class QuizAnswerUpdateModel:QuizAnswerCreateModel
    {
        public Guid Id { get; set; }
    }
}
