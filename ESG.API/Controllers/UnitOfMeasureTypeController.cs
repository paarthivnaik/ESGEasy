﻿using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasureTypeController : ControllerBase
    {
        private readonly ILogger<UnitOfMeasureTypeController> _logger;
        private readonly IUnitOfMeasureTypeService _unitOfMeasureTypeService;
        public UnitOfMeasureTypeController(ILogger<UnitOfMeasureTypeController> logger, IUnitOfMeasureTypeService unitOfMeasureTypeService)
        {
            _logger = logger;
            _unitOfMeasureTypeService = unitOfMeasureTypeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] List<UnitOfMeasureTypeCreateRequestDto> value)
        {
            
            try
            {
                await _unitOfMeasureTypeService.Add(value);
                return Ok(new { error = false, errorMsg = ""});
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(UnitOfMeasureTypeUpdateRequestDto value)
        {
            await _unitOfMeasureTypeService.UpdateAsync(value);
            return Ok();
        }

        [HttpPatch("Delete")]
        public async Task<IActionResult> Delete(UnitOfMeasureTypeDeleteRequestDto value)
        {
            await _unitOfMeasureTypeService.DeleteUOMType(value);
            return Ok();
        }

        [HttpGet("GetAllUOMTypes")]
        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAllUOMTypes(long organizationId)
        {
            return await _unitOfMeasureTypeService.GetAll(organizationId);
        }

        [HttpGet("GetAllUOMTypeTranslationsByUOMTypeId")]
        public async Task<IEnumerable<UnitOfMeasureTypeResponseDto>> GetAllTranslations(long Id)
        {
            return await _unitOfMeasureTypeService.GetAllTranslations(Id);
        }
        [HttpGet("GetAllUOMTypeTranslationsByLangId")]
        public async Task<IEnumerable<UnitOfMeasureType>> GetUOMTypeTranslationsByLangId(long languageId,long organizationId)
        {
            return await _unitOfMeasureTypeService.GetAllUOMTranslationsByUOMIdLangId(languageId, organizationId);
        }
    }
}
