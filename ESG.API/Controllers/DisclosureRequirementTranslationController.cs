using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DisclosureRequirementTranslationController : BaseController
    {
        private readonly ILogger<DisclosureRequirementTranslationController> _logger;
        private readonly IDisclosureRequirementTranslationService _disclosureRequirementTranslationService;
        public DisclosureRequirementTranslationController(ILogger<DisclosureRequirementTranslationController> logger, IDisclosureRequirementTranslationService disclosureRequirementTranslationService)
        {
            _logger = logger;
            _disclosureRequirementTranslationService = disclosureRequirementTranslationService;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslationsByLangId(long langId)
        {

            var list = await _disclosureRequirementTranslationService.GetDisclosureRequirementTranslations(langId);
            return list;
        }
        [HttpGet("GetById")]
        public async Task<IEnumerable<DisclosureRequirement>> GetDisclosureRequirementTranslationsById(long langId,long id)
        {

            var list = await _disclosureRequirementTranslationService.GetDisclosureRequirementTranslationsById(langId,id);
            return list;
        }
    }
}
