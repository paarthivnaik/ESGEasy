using ESG.Application;
using ESG.Application.Common.Interface.UnitOfMeasure;
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
        // GET: api/<UOMController>
        [HttpGet]
        public async Task<IEnumerable<UnitOfMeasureDto>> GetAll()
        {
            return await _unitOfMeasureService.GetAll();
        }

        // GET api/<UOMController>/5
        [HttpGet("{id}")]
        public async Task<UnitOfMeasureDto> Get(long id)
        {
            return await _unitOfMeasureService.GetById(id);
        }

        // POST api/<UOMController>
        [HttpPost]
        public async Task<int> Post([FromBody] UnitOfMeasureDto value)
        {
            return await _unitOfMeasureService.Add(value);
        }
        // POST api/<UOMController>
        [HttpPost("AddRange")]
        public async Task AddRange([FromBody] IEnumerable<UnitOfMeasureDto> value)
        {
            await _unitOfMeasureService.AddRange(value);
        }
        // PUT api/<UOMController>/5
        [HttpPut]
        public async Task Put(UnitOfMeasureDto value)
        {
           await _unitOfMeasureService.Update(value);
        }

    }
}
