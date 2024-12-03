using ESG.Application.Dto.Get;
using ESG.Application.Dto.Hierarchy;
using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
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
        public async Task<IActionResult> AddHierarchy([FromBody] HierarchyCreateRequestDto value)
        {
            try
            {
                await _hierarchyService.AddHierarchy(value);
                return Ok(new { error = false, errorMsg = "Hierarchy saved sucessully" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
        [HttpPost("CheckDataModelValueOfDatapoint")]
        public async Task<IActionResult> CheckDataModelValueOfDatapoint([FromBody] CheckDataModelValueOfDatapointRegDto requestDto)
        {
            try
            {
                bool hasValues = await _hierarchyService.CheckDataModelValueOfDatapoint(requestDto);
                return Ok(new {hasValue = hasValues});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred.", Details = ex.Message });
            }
        }

        [HttpGet("GetHierarchy")]
        /// <summary>
        /// when we pass table type 1 we need to get topic data
        /// when we pass tableType 2, DatapointId as topic DatapointId we get standard Data for that topic DatapointId
        /// when we pass tableType 3, DatapointId as standard DatapointId we get disclosurerequirement Data for that standard DatapointId
        /// when we pass tableType 4, DatapointId as disclosurerequirement DatapointId we get datapoint Data for that disclosurerequirement DatapointId
        /// </summary>
        /// <param name="tableType">1- Topic, 2-Standard, 3-DisclousureRequirement, 4- Datapoint</param>
        /// <param name="Id">this DatapointId is tableType foreign key</param>
        /// <returns></returns>
        public async Task<IEnumerable<HeirarchyDataResponseDto>> GetHeirarchy(int tableType, long? Id, long? organizationId)
        {
            var list = await _hierarchyService.GetMethod(tableType, Id, organizationId);
            return list;
        }
        [HttpGet("GetHierarchyByOrganizationId")]
        public async Task<HierarchyResponseDto> GetHierarchyByOrganizationId(long organizationId, long? languageId)
        {
            var list = await _hierarchyService.GetHierarchyByOrganizationId(organizationId, languageId);
            return list;
        }
        [HttpGet("GetDatapointsAssignedToUser")]
        public async Task<List<GetDatapointsAssignedToUserResponseDto>> GetDatapointsAssignedToUser(long OrganizationId, long userId)
        {
            var list = await _hierarchyService.GetDatapointsAssignedToUser(OrganizationId, userId);
            return list;
        }
        [HttpGet("GetDatapointsForDataModel")]
        public async Task<List<DatapointsForDataModelResponseDto>> GetDatapointsForDataModel(long organizationId, long? modelId, long? langaugeId)
        {
            var list = await _hierarchyService.GetDatapointsForDataModel(organizationId, modelId, langaugeId);
            return list;
        }
    }
}
