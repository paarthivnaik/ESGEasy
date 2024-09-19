using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetHierarch")]
        /// <summary>
        /// when we pass table type 1 we need to get topic data
        /// when we pass tableType 2, DatapointId as topic DatapointId we get standard Data for that topic DatapointId
        /// when we pass tableType 3, DatapointId as standard DatapointId we get disclosurerequirement Data for that standard DatapointId
        /// when we pass tableType 4, DatapointId as disclosurerequirement DatapointId we get datapoint Data for that disclosurerequirement DatapointId
        /// </summary>
        /// <param name="tableType">1- Topic, 2-Standard, 3-DisclousureRequirement, 4- Datapoint</param>
        /// <param name="Id">this DatapointId is tableType foreign key</param>
        /// <returns></returns>
        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetHeirarchy(int tableType, long? Id)
        {
            var list = await _hierarchyService.GetMethod(tableType, Id);
            return list;
        }
        [HttpGet("GetHierarchyByOrganizationId")]
        public async Task<HierarchyResponseDto> GetHierarchyByOrganizationId(long organizationId)
        {
            var list = await _hierarchyService.GetHierarchyByOrganizationId(organizationId);
            return list;
        }
        [HttpGet("GetDatapointsForDataModel")]
        public async Task<List<DatapointsForDataModelResponseDto>> GetDatapointsForDataModel(long organizationId)
        {
            var list = await _hierarchyService.GetDatapointsForDataModel(organizationId);
            return list;
        }
        //[HttpGet("GetUserDatapoints")]
        //public async Task<HierarchyResponseDto> GetUserDatapoints(long userId, long organizationId)
        //{
        //    var list = await _hierarchyService.GetUserDatapoints(userId, organizationId);
        //    return list;
        //}
    }
}
