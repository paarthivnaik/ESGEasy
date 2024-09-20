using ESG.Application.Dto.Dimensions;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DimensionsController : BaseController
    {
        private readonly ILogger<DimensionsController> _logger;
        private readonly IDimensionsService _dimensionsService;
        public DimensionsController(ILogger<DimensionsController> logger, IDimensionsService dimensionsService)
        {
            _logger = logger;
            _dimensionsService = dimensionsService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] List<DimensionCreateRequestDto> value)
        {
            await _dimensionsService.AddAsync(value);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] DimensionsUpdateRequestDto value)
        {
            await _dimensionsService.UpdateAsync(value);
            return Ok();
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(DimensionsDeleteRequestDto request)
        {
            await _dimensionsService.Delete(request);
            return Ok();
        }

        [HttpGet("GetAllDimensions")]
        public async Task<IEnumerable<DimensionsResponseDto>> Get()
        {
            return await _dimensionsService.GetAll();
        }

        [HttpGet("GetAllByDimensionTypeId")]
        public async Task<IEnumerable<DimensionsResponseDto>> GetById(long id)
        {
            return await _dimensionsService.GetById(id);
        }

        [HttpGet("GetAllDimensionTranslationsByDimensionTypeId")]

        public async Task<IEnumerable<DimensionsResponseDto>> GetAllTranslations(long id)
        {
            return await _dimensionsService.GetAllTranslations(id);
        }
    }
}
