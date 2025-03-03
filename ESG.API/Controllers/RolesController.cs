using ESG.Application.Dto.Roles;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace ESG.API.Controllers
{

    public class RolesController : BaseController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService  _roleService;
        public RolesController(ILogger<RolesController> logger, IRoleService  roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
             return await _roleService.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<Role> Get(int id)
        //{
        //    return await _roleService.GetById(id);
        //}

        [HttpPost("Create")]
        public async Task Post([FromBody] RoleCreationRequestDto value)
        {
            await _roleService.AddAsync(value);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] RoleCreationRequestDto value)
        {
            try
            {
                await _roleService.UpdateAsync(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex) {
                return Ok(new { error = true, errorMsg = ex.Message });

            }

        }

        //[HttpDelete("{id}")]
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var res = await _roleService.DeleteAsync(id);
        //    return res;
        //}
    }
}
