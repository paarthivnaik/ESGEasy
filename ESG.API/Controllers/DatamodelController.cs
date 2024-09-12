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
        public async Task<DataModelsResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long OrganizationId)
        {
            return await _dataModelService.GetingDataModelLinkedtoDatapoint(datapointId, OrganizationId);
        }
        [HttpPost("SavingDatapointDataInModel")]
        public async Task<IActionResult> SaveDatapointDataInModel(DatapointValuesSavingRequestDto datapointValuesSavingRequestDto)
        {
            await _dataModelService.SaveDatapointDataInModel(datapointValuesSavingRequestDto);
            return Ok();
        }
        //[HttpPost("ConfiguringModel")]
        //public async Task<IActionResult> ConfiguringModel(ConfiguringDataModelRequestDto configuringDataModelRequestDto)
        //{
        //    await _dataModelService.ConfiguringModel(configuringDataModelRequestDto);
        //    return Ok();
        //}
        //[HttpGet("GetModelDimensionTypesByModelId")]
        //public async Task<List<long>?> GetModelDimensionTypeByModelId(long id)
        //{
        //    return await _dataModelService.GetDimensionTypeByModelId(id);
        //}
        //[HttpGet("GetModelDimensionValuesByTypeId")]
        //public async Task<List<long>?> GetModelDimensionValuesByDimensionTypeId(long id)
        //{
        //    return await _dataModelService.GetDimensionValuesByTypeId(id);
        //}
    }
}
