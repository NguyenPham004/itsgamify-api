using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.Rooms
{
    public class RoomCreateModel
    {
        public int AmountQuestion { get; set; }
        public int TimeQuestion { get; set; }
        public float BetPoint { get; set; }
        public Guid ChallengeId { get; set; }
    }
}
