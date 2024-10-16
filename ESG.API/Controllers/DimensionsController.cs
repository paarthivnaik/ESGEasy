using ESG.Application.Dto.Dimension;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DimensionsController : BaseController
    {
        private readonly ILogger<DimensionsController> _logger;
        private readonly IDimensionService _dimensionsService;
        public DimensionsController(ILogger<DimensionsController> logger, IDimensionService dimensionsService)
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
        public async Task<IActionResult> Put([FromBody] DimensionUpdateRequestDto value)
        {
            await _dimensionsService.UpdateAsync(value);
            return Ok();
        }

        [HttpPatch("Delete")]
        public async Task<IActionResult> Delete(DimensionDeleteRequestDto request)
        {
            await _dimensionsService.Delete(request);
            return Ok();
        }

        [HttpGet("GetAllDimensions")]
        public async Task<IEnumerable<DimensionResponseDto>> Get(long organizationId)
        {
            return await _dimensionsService.GetAll(organizationId);
        }

        [HttpGet("GetDimensionByTypeId")]
        public async Task<IEnumerable<DimensionResponseDto>> GetById(long id, long organizationId)
        {
            return await _dimensionsService.GetById(id, organizationId);
        }

        [HttpGet("GetAllDimensionTranslationsByDimensionTypeId")]

        public async Task<IEnumerable<DimensionResponseDto>> GetAllTranslations(long id)
        {
            return await _dimensionsService.GetAllTranslations(id);
        }
    }
}
