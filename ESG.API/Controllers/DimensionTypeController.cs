using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
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
        public async Task Post([FromBody] DimensionType value)
        {
            await _dimentionTypeService.AddAsync(value);
        }

        [HttpPut("Update")]
        public async Task<DimensionType> Put([FromBody] DimensionType value)
        {
            var res = await _dimentionTypeService.UpdateAsync(value);
            return res;
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(int id)
        {
            var res = await _dimentionTypeService.Delete(id);
            return res;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<DimensionType>> Get()
        {
            return await _dimentionTypeService.GetAll();
        }

        [HttpGet("GetAllDimensionTypesById")]
        public async Task<DimensionType> GetById(int id)
        {
            return await _dimentionTypeService.GetById(id);
        }

        [HttpGet("GetAllDimensionTranslationsById")]
        public async Task<DimensionType> GetAllTranslations(int id)
        {
            return await _dimentionTypeService.GetById(id);
        }

    }
}
