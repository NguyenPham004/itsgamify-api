using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.Challenges
{
    public class ChallengeCreateModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumOfRoom { get; set; }
        public string ThumbnailImage { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
    }
}
