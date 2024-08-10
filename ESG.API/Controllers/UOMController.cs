using ESG.Application.Dto.UnitOfMeasure;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOMController : ControllerBase
    {
        private readonly ILogger<UOMController> _logger;
        private readonly IUnitOfMeasureService _unitOfMeasureService;
        public UOMController(ILogger<UOMController> logger, IUnitOfMeasureService unitOfMeasureService)
        {
            _logger = logger;
            _unitOfMeasureService = unitOfMeasureService;
        }

        // POST api/<UOMController>
        [HttpPost("Create UOM")]
        public async Task<IActionResult> Post([FromBody] UnitOfMeasureCreateRequestDto value)
        {
            await _unitOfMeasureService.Add(value);
            return Ok(200);
        }

        // PUT api/<UOMController>/5
        [HttpPut("Update UOM")]
        public async Task<IActionResult> Put(UnitOfMeasureUpdateRequestDto value)
        {
            await _unitOfMeasureService.Update(value);
            return Ok(200);
        }

        //// PUT api/<UOMController>/5
        //[HttpPut("Update UOM Translations")]
        //public async Task<IActionResult> Put(UnitOfMeasureUpdateRequestDto value)
        //{
        //    await _unitOfMeasureService.Update(value);
        //    return Ok(200);
        //}

        // PUT api/<UOMController>/5
        [HttpDelete("DeleteUOMType UOM")]
        public async Task<IActionResult> Delete(UnitOfMeasureDeleteRequest value)
        {
            await _unitOfMeasureService.DeleteUOM(value);
            return Ok(200);
        }

        // GET api/<UOMController>/5
        [HttpGet("Get all UOM By UOMTypeId")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetByTypeId(long id)
        {
            return await _unitOfMeasureService.GetAllUOMByUOMTypeId(id);
        }

        // GET api/<UOMController>/5
        [HttpGet("Get all UOM With Translatons")]
        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUOMTranslations(long id)
        {
            return await _unitOfMeasureService.GetAllUOMTranslations(id);
        }
    }
}
