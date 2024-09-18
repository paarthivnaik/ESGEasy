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
        
        [HttpGet("GetAllDatapoints")]
        public async Task<IEnumerable<DatapointValuesResponseDto>> Get()
        {
            return await _datapintValuesService.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<DataPointValues> Get(int id)
        //{
        //    return await _datapintValuesService.GetById(id);
        //}

        // POST api/<DatapointValuesController>
        [HttpPost("CreateOrUpdateDatapoint")]
        public async Task Post([FromBody] List<DatapointValueCreateRequestDto> value)
        {
            await _datapintValuesService.AddAsync(value);
        }

        [HttpDelete("DeleteDataPoint")]
        public async Task<IActionResult> Delete(DatapointDeleteRequestDto datapointDeleteRequestDto)
        {
            await _datapintValuesService.DeleteDatapoint(datapointDeleteRequestDto);
            return Ok();
        }

        //[HttpGet("GetDataPointsByOrganizationId")]
        //public async Task<IEnumerable<DatapointsByOrgIdResponseDto>> GetDataPointsByOrganizationId(long organizationId)
        //{
        //    var res = await _datapintValuesService.GetDataPointsByOrganizationId(organizationId);
        //    return res;
        //}
    }
}
