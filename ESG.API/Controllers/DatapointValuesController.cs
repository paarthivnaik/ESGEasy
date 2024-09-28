using ESG.Application.Dto.DatapointValue;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DatapointValuesController : ControllerBase
    {
        private readonly ILogger<DatapointValuesController> _logger;
        private readonly IDataPointValueService _datapintValuesService;
        public DatapointValuesController(ILogger<DatapointValuesController> logger, IDataPointValueService datapintValuesService)
        {
            _logger = logger;
            _datapintValuesService = datapintValuesService;
        }
        
        [HttpGet("GetAllDatapoints")]
        public async Task<IEnumerable<DataPointValueResponseDto>> Get()
        {
            return await _datapintValuesService.GetAll();
        }


        [HttpPost("CreateOrUpdateDatapoint")]
        public async Task Post([FromBody] List<DatapointValueCreateRequestDto> value)
        {
            await _datapintValuesService.AddAsync(value);
        }

        [HttpPatch("DeleteDataPointById")]
        public async Task<IActionResult> Delete(long id)
        {
            await _datapintValuesService.DeleteDatapoint(id);
            return Ok();
        }
    }
}
