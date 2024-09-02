using ESG.Application.Dto.Get;
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
        [HttpGet("GetHierarchy")]
        /// <summary>
        /// when we pass table type 1 we need to get topic data
        /// when we pass tableType 2, Id as topic Id we get standard Data for that topic Id
        /// when we pass tableType 3, Id as standard Id we get disclosurerequirement Data for that standard Id
        /// when we pass tableType 4, Id as disclosurerequirement Id we get datapoint Data for that disclosurerequirement Id
        /// </summary>
        /// <param name="tableType">1- Topic, 2-Standard, 3-DisclousureRequirement, 4- Datapoint</param>
        /// <param name="Id">this Id is tableType foreign key</param>
        /// <returns></returns>
        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetHeirarchy(int tableType, long? Id)
        {
            var list = await _hierarchyService.GetMethod(tableType, Id);
            return list;
        }
        [HttpGet("GetHierarchyIdByOrgId")]
        public async Task<IEnumerable<HierarchyResponseDto>> GetHierarchyData(long organizationId)
        {
            var list = await _hierarchyService.GetHierarchydata(organizationId);
            return list;
        }
    }
}
