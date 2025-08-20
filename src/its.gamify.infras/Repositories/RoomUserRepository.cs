using its.gamify.core.Repositories;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.infras.Datas;

namespace its.gamify.infras.Repositories
{
    public class RoomUserRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : GenericRepository<RoomUser>(context, currentTime, claimsService), IRoomUserRepository
    {
    }
}
