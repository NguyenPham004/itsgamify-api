using its.gamify.core.Repositories;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.infras.Datas;

namespace its.gamify.infras.Repositories
{
    public class CourseDepartmentRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : GenericRepository<CourseDepartment>(context, timeService, claimsService), ICourseDepartmentRepository
    {
    }
}
