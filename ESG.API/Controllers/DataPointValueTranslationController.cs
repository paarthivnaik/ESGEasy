using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DataPointValueTranslationController : BaseController
    {
        private readonly ILogger<DataPointValueTranslationController> _logger;
        private readonly IDataPointValueTranslationService _dataPointValueTranslationService;
        public DataPointValueTranslationController(ILogger<DataPointValueTranslationController> logger, IDataPointValueTranslationService dataPointValueTranslationService)
        {
            _logger = logger;
            _dataPointValueTranslationService = dataPointValueTranslationService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UOMTranslationsCreateRequestDto value)
        {
            try
            {
                await _dataPointValueTranslationService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
    }
}
