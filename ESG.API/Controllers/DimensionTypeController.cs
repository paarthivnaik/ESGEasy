using ESG.Application.Dto.Dimensions;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services;
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
        private readonly IDimentionTypeService _dimentionTypeService;
        public DimensionTypeController(ILogger<DimensionTypeController> logger, IDimentionTypeService dimentionTypeService)
        {
            _logger = logger;
            _dimentionTypeService = dimentionTypeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] List<DimensionTypeCreateRequestDto> value)
        {
            await _dimentionTypeService.AddAsync(value);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] DimensionTypeUpdateRequestDto value)
        {
            await _dimentionTypeService.UpdateAsync(value);
            return Ok();
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(DimensionTypeDeleteRequestDto request)
        {
            await _dimentionTypeService.Delete(request);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<DimensionTypeResponseDto>> Get()
        {
            return await _dimentionTypeService.GetAll();
        }


    }
}
