using its.gamify.core.Repositories;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.infras.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.infras.Repositories
{
    public class UserChallengeHistoryRepository : GenericRepository<UserChallengeHistory>, IUserChallengeHistoryRepository
    {
        public UserChallengeHistoryRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }
    }
}
