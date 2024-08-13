using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Dto.UnitOfMeasureType;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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

        // POST api/<UOMController>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UnitOfMeasureCreateRequestDto value)
        {
            await _unitOfMeasureService.Add(value);
            return Ok();
        }

        // PUT api/<UOMController>/5
        [HttpPut("Update")]
        public async Task<IActionResult> Put(UnitOfMeasureUpdateRequestDto value)
        {
            await _unitOfMeasureService.Update(value);
            return Ok();
        }

        // PUT api/<UOMController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(UnitOfMeasureDeleteRequest value)
        {
            await _unitOfMeasureService.DeleteUOM(value);
            return Ok();
        }

        //// GET api/<UOMController>/5
        [HttpGet("GetAllUOMTypes")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAll()
        {
            return await _unitOfMeasureService.GetAll();
        }

        // GET api/<UOMController>/5
        [HttpGet("GetAllUOM")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetByTypeId(long id)
        {
            return await _unitOfMeasureService.GetAllUOMByUOMTypeId(id);
        }

        // GET api/<UOMController>/5
        [HttpGet("GetAllUOMTranslatons")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslations(long id)
        {

            return await _unitOfMeasureService.GetAllUOMTranslations(id);
        }
    }
}
