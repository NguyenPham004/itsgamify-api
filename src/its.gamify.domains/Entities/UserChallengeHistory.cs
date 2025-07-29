using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.domains.Entities
{
    public class UserChallengeHistory: BaseEntity
    {
        public string Score { get; set; } =string.Empty;
        public string OpponentScore { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public Guid ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; } = null!;
    }
}
