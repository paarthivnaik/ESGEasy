using ESG.Application.Dto.Language;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class LanguageController :BaseController
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageService _languageService;
        public LanguageController(ILogger<LanguageController> logger, ILanguageService languageService)
        {
            _logger = logger;
            _languageService = languageService;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<LanguageDto>> Get()
        {
           return await _languageService.GetAll();
        }
        [HttpGet("GetById")]
        public async Task<LanguageDto> GetById(long id)
        {
            return await _languageService.GetById(id);
        }
        [HttpGet("GetLanguageTranslationsByLanguageId")]
        public async Task<IEnumerable<LanguageTranslation>> GetLanguageTranslationsByLanguageId(long languageId)
        {
            return await _languageService.GetLanguageTranslationsByLanguageId(languageId);
        }
    }
}
