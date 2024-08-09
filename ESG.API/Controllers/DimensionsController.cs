using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsController : ControllerBase
    {
        private readonly ILogger<DimensionsController> _logger;
        private readonly IDimensionsService _dimensionsService;
        public DimensionsController(ILogger<DimensionsController> logger, IDimensionsService dimensionsService)
        {
            _logger = logger;
            _dimensionsService = dimensionsService;
        }
        // GET: api/<DimensionsController>
        [HttpGet]
        public async Task<IEnumerable<Dimensions>> Get()
        {
            return await _dimensionsService.GetAll();
        }

        // GET api/<DimensionsController>/5
        [HttpGet("{id}")]
        public async Task<Dimensions> Get(int id)
        {
            return await _dimensionsService.GetById(id);
        }

        // POST api/<DimensionsController>
        [HttpPost]
        public async Task Post([FromBody] Dimensions value)
        {
            await _dimensionsService.AddAsync(value);
        }

        // PUT api/<DimensionsController>/5
        [HttpPut("{id}")]
        public async Task<Dimensions> Put([FromBody] Dimensions value)
        {
            var res = await _dimensionsService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<DimensionsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _dimensionsService.Delete(id);
            return res;
        }
    }
}
