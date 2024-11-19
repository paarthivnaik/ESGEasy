using ESG.Application.Dto.DataModel;
using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
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
            try
            {
                await _dataModelService.CreateDataModel(dataModelCreateRequestDto);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
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
        [HttpPost("SavingDatapointDataInModel")]
        public async Task<IActionResult> SaveDatapointDataInModel(DataPointValueSavingRequestDto datapointValuesSavingRequestDto)
        {
            try
            {
                await _dataModelService.SaveDatapointDataInModel(datapointValuesSavingRequestDto);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }
        [HttpPost("GetDatapointSavedValues")]
        public async Task<DatapointSavedValuesResponseDto> GetDatapointSavedValues(DatapointSavedValuesRequestDto datapointSavedValuesRequestDto)
        {
            return await _dataModelService.GetDatapointSavedValues(datapointSavedValuesRequestDto);
        }
        [HttpGet("GetDataModelValuesForAssigningUsers")]
        public async Task<GetDataModelValuesForAssigningUsersResponseDto> GetDataModelValuesForAssigningUsers(long dataModelId, long organizationId)
        {
            return await _dataModelService.GetDataModelValuesForAssigningUsers(dataModelId, organizationId);
        }
        [HttpPost("AssignUsersToDataModelValues")]
        public async Task<IActionResult> AssignUsersToDataModelValues(AssigningDataModelValuesToUsersRequestDto requestDto)
        {
            await _dataModelService.AssignUsersToDataModelValues(requestDto);
            return Ok();
        }
        [HttpGet("GetDatapointsLinkedToDataModel")]
        public async Task<List<long>?> GetDatapointsLinkedToDataModel(long modelId, long OrganizationId)
        {
            var list = await _dataModelService.GetDatapointsLinkedToDataModel(modelId, OrganizationId);
            return list;
        }
    }
}
