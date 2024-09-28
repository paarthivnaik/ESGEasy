using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESG.API.Controllers
{

    public class UserRolesController : BaseController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IUserRoles _roleService;
        public UserRolesController(ILogger<RolesController> logger, IUserRoles roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _roleService.GetAll();
            return Ok(res);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var res = await _roleService.GetRolesByUserId(id);
        //    return Ok(res);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(UserRole userRole)
        //{
        //    await _roleService.Create(userRole);
        //    return Ok();
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(UserRole userRole)
        //{
        //   var res= await _roleService.Update(userRole);
        //    return Ok(res);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //     await _roleService.Delete(id);
        //    return Ok();
        //}
    }
}
