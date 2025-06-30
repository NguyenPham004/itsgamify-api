using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class IndexController : BaseController
    {
        private readonly IClaimsService claimsService;
        public IndexController(IClaimsService claimsService)
        {
            this.claimsService = claimsService;
        }
        [HttpGet]
        [Authorize(Roles = nameof(RoleEnum.ADMIN))]
        public IActionResult Get()
        {
            var user = claimsService.CurrentUser;
            return Ok();
        }
    }
}
