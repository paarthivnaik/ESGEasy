using ESG.Application.Dto.DatapointType;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities.DomainEntities;
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

        [HttpGet]
        public async Task<IEnumerable<DataPointTypes>> Get()
        {
            return await _datapointTypesService.GetAll();
        }

        [HttpPost]
        public async Task Post([FromBody] List<DatapointTypeCreateRequestDto> value)
        {
            await _datapointTypesService.AddAsync(value);
        }

    }
}

