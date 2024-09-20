using ESG.Application.Dto.DataModel;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DatamodelController : BaseController
    {
        private readonly ILogger<DatamodelController> _logger;
        private readonly IDataModelService _dataModelService;
        public DatamodelController(ILogger<DatamodelController> logger, IDataModelService dataModelService)
        {
            _logger = logger;
            _dataModelService = dataModelService;
        }
        [HttpPost("CreateDatamodel")]
        public async Task<IActionResult> CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        {
            await _dataModelService.CreateDataModel(dataModelCreateRequestDto);
            return Ok();
        }
        [HttpGet("GetDataModelsForOrganization")]
        public async Task<IEnumerable<DataModelsResponseDto>> GetDataModelsForOrganization(long OrganizationId)
        {
            return await _dataModelService.GetDataModelsResponsesByOrgId(OrganizationId);
        }
        [HttpGet("GetingDataModelLinkedtoDatapoint")]
        public async Task<DataModelLinkedtoDatapointResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long OrganizationId)
        {
            return await _dataModelService.GetingDataModelLinkedtoDatapoint(datapointId, OrganizationId);
        }
        [HttpGet("GetDatapointMetricDetailsForDataModel")]
        public async Task<DatapointMetricResponseDto> GetHierarchyDatapointsMetricDetails(long datapointId, long OrganizationId)
        {
            return await _dataModelService.GetDatapointMetric(datapointId, OrganizationId);
        }
        [HttpPost("SavingDatapointDataInModel")]
        public async Task<IActionResult> SaveDatapointDataInModel(DataPointValuesSavingRequestDto datapointValuesSavingRequestDto)
        {
            await _dataModelService.SaveDatapointDataInModel(datapointValuesSavingRequestDto);
            return Ok();
        }
    }
}
