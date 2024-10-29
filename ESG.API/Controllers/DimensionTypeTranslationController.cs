using ESG.Application.Dto.DimensionTypeTranslation;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DimensionTypeTranslationController : BaseController
    {
        private readonly ILogger<DimensionTypeTranslationController> _logger;
        private readonly IDimensionTypeTranslationService _dimensionTypeTranslationService;
        public DimensionTypeTranslationController(ILogger<DimensionTypeTranslationController> logger, IDimensionTypeTranslationService dimensionTypeTranslationService)
        {
            _logger = logger;
            _dimensionTypeTranslationService = dimensionTypeTranslationService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] DimensionTypeTranslationCreateRequestDto value)
        {
            try
            {
                await _dimensionTypeTranslationService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
    }
}
