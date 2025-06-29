using its.gamify.core;
using its.gamify.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    public class RolesController(IRoleService roleService) : BaseController
    {
        private readonly IRoleService _roleService = roleService;
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _roleService.GetAllAsync();
            return Ok(
                new { data = result.Item2, pagination = result.Item1 }
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleModel model)
        {
            var result = await _roleService.CreateAsync(model);
            return Ok(result);
        }
    }
}
