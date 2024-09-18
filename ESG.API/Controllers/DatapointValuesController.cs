using ESG.Application.Dto.DatapointValue;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        //[HttpGet("GetDataPointsByOrganizationId")]
        //public async Task GetDataPointsByOrganizationId(long organizationId)
        //{
        //}


        //[HttpGet("GetDataPointDataByOrganizationId")]
        //public async Task<DatapointsByOrgIdResponseDto> GetDataPointDataByOrganizationId(long organizationId)
        //{
        //   var res =  new DatapointsByOrgIdResponseDto();
        //    return  res;
        //}

        //[HttpGet("GetDataPointsByOrganizationId")]
        //public async Task<DatapointsByOrgIdResponseDto> Get(long organizationId)
        //{
        //    var res = await _datapintValuesService.GetDataPointsByOrganizationId(organizationId);
        //    return res;
        //}

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

        

    }
}
