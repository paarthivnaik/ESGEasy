using ESG.Application.Dto.DimensionTranslation;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DimensionTranslationController : BaseController
    {
        private readonly ILogger<DimensionTranslationController> _logger;
        private readonly IDimensionTranslationService _dimensionTranslationService;
        public DimensionTranslationController(ILogger<DimensionTranslationController> logger, IDimensionTranslationService dimensionTranslationService)
        {
            _logger = logger;
            _dimensionTranslationService = dimensionTranslationService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] DimensionTranslationCreateRequestDto value)
        {
            try
            {
                await _dimensionTranslationService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
        [HttpGet("GetDimensionTranslationsByDimensionIdLangId")]
        public async Task<IEnumerable<Dimension>> GetDimensionTranslationsByDimensionIdLangId(long dimensionTypeId,long languageId, long organizationId)
        {
            var list = await _dimensionTranslationService.GetDimensionTranslationsByDimensionTypeId(dimensionTypeId, languageId, organizationId);
            return list;
        }
    }
}
