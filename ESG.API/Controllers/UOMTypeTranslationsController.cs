using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Dto.UOMTypeTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class UOMTypeTranslationsController : BaseController
    {
        private readonly ILogger<UOMTypeTranslationsController> _logger;
        private readonly IUOMTypeTranslationsService _uomTypeTranslationsService;
        public UOMTypeTranslationsController(IUOMTypeTranslationsService uomTypeTranslationsService, ILogger<UOMTypeTranslationsController> logger)
        {
            _logger = logger;
            _uomTypeTranslationsService = uomTypeTranslationsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UOMTypeTranslationsCreateRequestDto value)
        {
            try
            {
                await _uomTypeTranslationsService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
        [HttpGet("GetAllUOMTypeTranslationsByLanguageId")]
        public async Task<IEnumerable<UnitOfMeasureType>> GetUOMTranslationsByLanguageId(long languageId,long organizationId)
        {
            var list = await _uomTypeTranslationsService.GetUOMTypeTranslationByID(languageId,organizationId);
            return list;
        }

        //[HttpPut("Update")]
        //public async Task<IActionResult> Put([FromBody] UOMTypeTranslationsUpdateRequestDto value)
        //{
        //    await _uomTypeTranslationsService.Update(value);
        //    return Ok();
        //}
    }
}
