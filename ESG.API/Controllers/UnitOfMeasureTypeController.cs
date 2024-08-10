using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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

        //POST api/<UOMController>
        [HttpPost("Create UOM Type")]
        public async Task<IActionResult> Post([FromBody] UnitOfMeasureTypeCreateRequestDto value)
        {
            await _unitOfMeasureTypeService.Add(value);
            return Ok(200);
        }

        //// PUT api/<UOMController>/5
        [HttpPut("Update UOM Type")]
        public async Task<IActionResult> Put(UnitOfMeasureTypeUpdateRequestDto value)
        {
            await _unitOfMeasureTypeService.UpdateAsync(value);
            return Ok(200);
        }

        //// PUT api/<UOMController>/5
        [HttpDelete("DeleteUOMType UOM Type")]
        public async Task<IActionResult> Delete(UnitOfMeasureTypeDeleteRequestDto value)
        {
            await _unitOfMeasureTypeService.DeleteUOMType(value);
            return Ok(200);
        }

        //// GET api/<UOMController>/5
        [HttpGet("Get all UOMTypes")]
        public async Task<IEnumerable<unitOfMeasureTypeResponseDto>> GetAllUOMTypes()
        {
            return await _unitOfMeasureTypeService.GetAll();
        }

        //// GET api/<UOMController>/5
        [HttpGet("Get all UOM With Translatons")]
        public async Task<IEnumerable<unitOfMeasureTypeResponseDto>> GetAllTranslations(long Id)
        {
            return await _unitOfMeasureTypeService.GetAllTranslations(Id);

        }
    }
}
