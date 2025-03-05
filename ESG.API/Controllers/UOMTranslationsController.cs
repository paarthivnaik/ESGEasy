
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class UOMTranslationsController : BaseController
    {
        private readonly ILogger<UOMTranslationsController> _logger;
        private readonly IUOMTranslationsService _uomTranslationsService;
        public UOMTranslationsController(IUOMTranslationsService uomTranslationsService, ILogger<UOMTranslationsController> logger)
        {
            _logger = logger;
            _uomTranslationsService = uomTranslationsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UOMTranslationsCreateRequestDto value)
        {
            try
            {
                await _uomTranslationsService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
        [HttpGet("GetUOMTranslationsByLanguageId")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetUOMTranslationsByLanguageId(long languageId)
        {
            var list = await _uomTranslationsService.GetUOMTranslationsByLanguageId(languageId);
            return list;
        }
        //[HttpPut("Update")]
        //public async Task<IActionResult> Put([FromBody] UOMTranslationsUpdateRequestDto value)
        //{
        //    await _uomTranslationsService.Update(value);
        //    return Ok();
        //}
    }
}
