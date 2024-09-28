using ESG.Application.Dto.Currency;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class CurrencyController : BaseController
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet("GetCurrencies")]
        public async Task<IEnumerable<CurrencyResponseDto>> GetAll()
        {
            _logger.LogInformation("Getting all currencies.");
            return await _currencyService.GetAll();
        }
    }

}
