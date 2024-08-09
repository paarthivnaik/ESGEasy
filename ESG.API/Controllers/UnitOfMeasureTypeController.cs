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
        private readonly IUnitOfMeasureTypeService _unitOfMeasuretypeService;
        public UnitOfMeasureTypeController(ILogger<UnitOfMeasureTypeController> logger, IUnitOfMeasureTypeService unitOfMeasureTypeService)
        {
            _logger = logger;
            _unitOfMeasuretypeService = unitOfMeasureTypeService;
        }
        // GET: api/<UnitOfMeasureTypeController>
        [HttpGet]
        public async Task<IEnumerable<UnitOfMeasureType>> Get()
        {
            return await _unitOfMeasuretypeService.GetAll();
        }

        // GET api/<UnitOfMeasureTypeController>/5
        [HttpGet("{id}")]
        public async Task<UnitOfMeasureType> Get(int id)
        {
            return await _unitOfMeasuretypeService.GetById(id);
        }

        // POST api/<UnitOfMeasureTypeController>
        [HttpPost]
        public async Task Post([FromBody] UnitOfMeasureType value)
        {
            await _unitOfMeasuretypeService.AddAsync(value);
        }

        // PUT api/<UnitOfMeasureTypeController>/5
        [HttpPut("{id}")]
        public async Task<UnitOfMeasureType> Put([FromBody] UnitOfMeasureType value)
        {
            var res = await _unitOfMeasuretypeService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<UnitOfMeasureTypeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _unitOfMeasuretypeService.Delete(id);
            return res;
        }
    }
}
