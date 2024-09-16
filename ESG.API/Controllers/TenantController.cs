using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{

    public class TenantController : BaseController
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantService _tenantService;
        public TenantController(ILogger<TenantController> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _tenantService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _tenantService.GetById(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Tenant value)
        {
            await _tenantService.AddAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<Tenant> Put(Tenant value)
        {
            var res = await _tenantService.UpdateAsync(value);
            return res;
        }
    }
}
