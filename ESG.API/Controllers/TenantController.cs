using ESG.Application.Common.Interface.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantService _tenantService;
        public TenantController(ILogger<TenantController> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task< IEnumerable<Tenant>> Get()
        {
            var res = await _tenantService.GetAll();
            return res;
        }

        // GET api/<TenantController>/5
        [HttpGet("{id}")]
        public async Task<Tenant> Get(int id)
        {
            var res = await _tenantService.GetById(id);
            return res;
        }
        [HttpPost]
        public async Task<Tenant> Post(Tenant value)
        {
            var res= await _tenantService.AddAsync(value);
            
            return res;
        }

        [HttpPut]
        public async Task<Tenant> Put(Tenant value)
        {
            var res = await _tenantService.UpdateAsync(value);
            return res;
        }
    }
}
