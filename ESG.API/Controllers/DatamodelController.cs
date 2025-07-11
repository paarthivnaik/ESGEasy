﻿using ESG.Application.Dto.DataModel;
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
        [HttpPost("CreateOrEditDatamodel")]
        public async Task<IActionResult> CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        {
            try
            {
                await _dataModelService.CreateDataModel(dataModelCreateRequestDto);
                if(dataModelCreateRequestDto.DataModelId > 0)
                {
                    return Ok(new { error = false, errorMsg = "2" });
                }
                return Ok(new { error = false, errorMsg = "1" });
                
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

        //[HttpPost("EditDatamodel")]
        //public async Task<IActionResult> EditDataModel(DataModelCreateRequestDto dataModelUpdateRequestDto)
        //{
        //    try
        //    {
        //        await _dataModelService.EditDataModel(dataModelUpdateRequestDto);
        //        return Ok(new { error = false, errorMsg = "" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { error = true, errorMsg = ex.Message });
        //    }
        //}
        [HttpGet("GetDataModelsForOrganization")]
        public async Task<IEnumerable<DataModelsResponseDto>> GetDataModelsForOrganization(long OrganizationId, long languageId)
        {
            return await _dataModelService.GetDataModelsResponsesByOrgId(OrganizationId,languageId);
        }
        [HttpGet("GetingDataModelLinkedtoDatapoint")]
        public async Task<DataModelLinkedtoDatapointResponseDto> GetingDataModelLinkedtoDatapoint(long datapointId, long OrganizationId, long languageId)
        {
            return await _dataModelService.GetingDataModelLinkedtoDatapoint(datapointId, OrganizationId, languageId);
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
        public async Task<GetDataModelValuesForAssigningUsersResponseDto> GetDataModelValuesForAssigningUsers(long dataModelId, long organizationId,long languageId)
        {
            return await _dataModelService.GetDataModelValuesForAssigningUsers(dataModelId, organizationId, languageId);
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
