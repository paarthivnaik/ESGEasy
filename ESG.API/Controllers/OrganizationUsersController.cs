using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace ESG.API.Controllers
{

    public class OrganizationUsersController : BaseController
    {
        private readonly ILogger<OrganizationUsersController> _logger;
        private readonly IOrganizationUsersService _organizationUsersService;
        public OrganizationUsersController(ILogger<OrganizationUsersController> logger, IOrganizationUsersService organizationUsersService)
        {
            _logger = logger;
            _organizationUsersService = organizationUsersService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _organizationUsersService.GetAll();
            return Ok(res);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var res = await _organizationUsersService.GetById(id);
        //    return Ok(res);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(OrganizationUser organizationUser)
        //{
        //    await _organizationUsersService.AddAsync(organizationUser);
        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(OrganizationUser organizationUser)
        //{
        //    var res = await _organizationUsersService.UpdateAsync(organizationUser);
        //    return Ok(res);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _organizationUsersService.Delete(id);
        //    return Ok();
        //}
    }
}
