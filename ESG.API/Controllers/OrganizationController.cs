using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{

    public class OrganizationController : BaseController
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationService _organizationService;
        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService organizationService)
        {
            _logger = logger;
            _organizationService = organizationService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _organizationService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _organizationService.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Organization organization)
        {
            await _organizationService.AddAsync(organization);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Organization organization)
        {
            var res = await _organizationService.UpdateAsync(organization);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _organizationService.Delete(id);
            return Ok();
        }
    }
}
