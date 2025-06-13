using its.gamify.core;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        public RolesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.RoleRepository.GetAllAsync());
        }
    }
}
