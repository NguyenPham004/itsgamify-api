using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.infras.Datas;
namespace its.gamify.infras.Repositories
{
    public class RoleRepository : GenericRepository<Role>, its.gamify.core.Repositories.IRoleRepository
    {
        public RoleRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
        {
        }
    }
}
