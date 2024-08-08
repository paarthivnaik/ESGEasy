using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatapointTypesController : ControllerBase
    {
        private readonly ILogger<DatapointTypesController> _logger;
        private readonly IDatapointTypesService _datapointTypesService;
        public DatapointTypesController(ILogger<DatapointTypesController> logger, IDatapointTypesService datapointTypesService)
        {
            _logger = logger;
            _datapointTypesService = datapointTypesService;
        }
        // GET: api/<DatapointTypesController>
        [HttpGet]
        public async Task<IEnumerable<DataPointTypes>> Get()
        {
            return await _datapointTypesService.GetAll();
        }

        // GET api/<DatapointTypesController>/5
        [HttpGet("{id}")]
        public async Task<DataPointTypes> Get(int id)
        {
            return await _datapointTypesService.GetById(id);
        }

        // POST api/<DatapointTypesController>
        [HttpPost]
        public async Task<DataPointTypes> Post([FromBody] DataPointTypes value)
        {
            var res = await _datapointTypesService.AddAsync(value);

            return res;
        }

        // PUT api/<DatapointTypesController>/5
        [HttpPut("{id}")]
        public async Task<DataPointTypes> Put([FromBody] DataPointTypes value)
        {
            var res = await _datapointTypesService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<DatapointTypesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _datapointTypesService.Delete(id);
            return res;
        }
    }
}

