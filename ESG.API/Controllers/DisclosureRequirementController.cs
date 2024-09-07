using ESG.Application.Dto.DisclosureRequirement;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DisclosureRequirementController : BaseController
    {
        private readonly Logger<DisclosureRequirementController> _logger;
        private readonly IDisclosureRequirementService _disclosureRequirementService;
        public DisclosureRequirementController(ILogger<DisclosureRequirementController> logger, IDisclosureRequirementService disclosureRequirementService)
        {
            _logger = (Logger<DisclosureRequirementController>?)logger;
            _disclosureRequirementService = disclosureRequirementService;
        }
        [HttpGet("GetAllDisclosureRequirements")]
        public async Task<IEnumerable<DisclosureRequirementResponseDto>> GetAll()
        {
            return await _disclosureRequirementService.GetAll();
        }
    }
}
