using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESG.API.Controllers
{
    public class UOMController : BaseController
    {
        private readonly ILogger<UOMController> _logger;
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UOMController(ILogger<UOMController> logger, IUnitOfMeasureService unitOfMeasureService)
        {
            _logger = logger;
            _unitOfMeasureService = unitOfMeasureService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] List<UnitOfMeasureCreateRequestDto> value)
        {
            await _unitOfMeasureService.Add(value);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(UnitOfMeasureUpdateRequestDto value)
        {
            await _unitOfMeasureService.Update(value);
            return Ok();
        }

        [HttpPatch("Delete")]
        public async Task<IActionResult> Delete(UnitOfMeasureDeleteRequest value)
        {
            await _unitOfMeasureService.DeleteUOM(value);
            return Ok();
        }

        [HttpGet("GetAllUOMs")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll()
        {
            return await _unitOfMeasureService.GetAll();
        }

        [HttpGet("GetAllUOMsByUOMTypeId")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMByUOMTypeId(long id)
        {
            return await _unitOfMeasureService.GetAllUOMByUOMTypeId(id);
        }

        [HttpGet("GetAllUOMTranslatonsByUOMId")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslationsByUOMId(long id)
        {

            return await _unitOfMeasureService.GetAllUOMTranslationsByUOMId(id);
        }
    }
}
