using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class CurrencyTranslationController : BaseController
    {
        private readonly ILogger<CurrencyTranslationController> _logger;
        private readonly ICurrencyTranslationService _currencyTranslationService;
        public CurrencyTranslationController(ILogger<CurrencyTranslationController> logger, ICurrencyTranslationService currencyTranslationService)
        {
            _logger = logger;
            _currencyTranslationService = currencyTranslationService;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<Currency>> GetCurrencyTranslationsByLangId(long languageId)
        {

            var list = await _currencyTranslationService.GetCurrencyTranslations(languageId);
            return list;
        }
    }
}
