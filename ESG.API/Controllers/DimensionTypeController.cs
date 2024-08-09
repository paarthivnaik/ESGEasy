using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionTypeController : ControllerBase
    {
        private readonly ILogger<DimensionTypeController> _logger;
        private readonly IDimentionTypeService _roleService;
        public DimensionTypeController(ILogger<DimensionTypeController> logger, IDimentionTypeService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        // GET: api/<DimensionTypeController>
        [HttpGet]
        public async Task<IEnumerable<DimensionType>> Get()
        {
            return await _roleService.GetAll();
        }

        // GET api/<DimensionTypeController>/5
        [HttpGet("{id}")]
        public async Task<DimensionType> Get(int id)
        {
            return await _roleService.GetById(id);
        }

        // POST api/<DimensionTypeController>
        [HttpPost]
        public async Task Post([FromBody] DimensionType value)
        {
            await _roleService.AddAsync(value);
        }

        // PUT api/<DimensionTypeController>/5
        [HttpPut("{id}")]
        public async Task<DimensionType> Put([FromBody] DimensionType value)
        {
            var res = await _roleService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<DimensionTypeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _roleService.Delete(id);
            return res;
        }
    }
}
