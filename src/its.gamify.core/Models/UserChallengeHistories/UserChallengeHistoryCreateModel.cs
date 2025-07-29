using its.gamify.domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.UserChallengeHistories
{
    public class UserChallengeHistoryCreateModel
    {
        public string Score { get; set; } = string.Empty;
        public string OpponentScore { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid ChallengeId { get; set; }
    }
}
