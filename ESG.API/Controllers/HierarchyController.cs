using ESG.Application.Dto.Hierarchy;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HierarchyController : ControllerBase
    {
        private readonly ILogger<HierarchyController> _logger;
        private readonly IHierarchyService _hierarchyService;
        public HierarchyController(IHierarchyService hierarchyService, ILogger<HierarchyController> logger)
        {
            _logger = logger;
            _hierarchyService = hierarchyService;
        }
        [HttpPost("CreateHierarchy")]
        public async Task<IActionResult> Post([FromBody] HierarchyCreateRequestDto value)
        {
            await _hierarchyService.AddHierarchy(value);
            return Ok();
        }
    }
}
