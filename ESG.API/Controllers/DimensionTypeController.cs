using ESG.Application.Dto.DimensionTypes;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionTypeController : ControllerBase
    {
        private readonly ILogger<DimensionTypeController> _logger;
        private readonly IDimentionTypeService _dimentionTypeService;
        public DimensionTypeController(ILogger<DimensionTypeController> logger, IDimentionTypeService dimentionTypeService)
        {
            _logger = logger;
            _dimentionTypeService = dimentionTypeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] List<DimensionTypeCreateRequestDto> value)
        {
            try
            {
                await _dimentionTypeService.AddAsync(value);
                return Ok(new { error = false, errorMsg = ""});
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] DimensionTypeUpdateRequestDto value)
        {
            await _dimentionTypeService.UpdateAsync(value);
            return Ok();
        }

        [HttpPatch("Delete")]
        public async Task<IActionResult> Delete([FromBody] DimensionTypeDeleteRequestDto request)
        {
            await _dimentionTypeService.SoftDelete(request);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<DimensionTypeResponseDto>> Get(long organizationId)
        {
            return await _dimentionTypeService.GetAll(organizationId);
        }


    }
}
