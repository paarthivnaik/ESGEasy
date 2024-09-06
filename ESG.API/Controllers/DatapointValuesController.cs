using ESG.Application.Dto.DatapointValue;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatapointValuesController : ControllerBase
    {
        private readonly ILogger<DatapointValuesController> _logger;
        private readonly IDatapointValuesService _datapintValuesService;
        public DatapointValuesController(ILogger<DatapointValuesController> logger, IDatapointValuesService datapintValuesService)
        {
            _logger = logger;
            _datapintValuesService = datapintValuesService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DatapointValuesResponseDto>> Get()
        {
            return await _datapintValuesService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<DataPointValues> Get(int id)
        {
            return await _datapintValuesService.GetById(id);
        }

        // POST api/<DatapointValuesController>
        [HttpPost]
        public async Task Post([FromBody] DatapointValueCreateRequestDto value)
        {
            await _datapintValuesService.AddAsync(value);
        }

        // PUT api/<DatapointValuesController>/5
        [HttpPut("{id}")]
        public async Task<DataPointValues> Put([FromBody] DataPointValues value)
        {
            var res = await _datapintValuesService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<DatapointValuesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _datapintValuesService.Delete(id);
            return res;
        }
    }
}
