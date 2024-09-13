using ESG.Application.Dto.Get;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IValuesService _valueService;
        public ValuesController(ILogger<ValuesController> logger, IValuesService valueService)
        {
            _logger = logger;
            _valueService = valueService;
        }
        [HttpGet("Get")]
        /// <summary>
        /// when we pass table type and typeId we need to get respective table type data.
        /// when we pass tableType, typeId, valueId we need to get respective values translations for a given table.
        /// table Type and TypeId are mandatory parameters, valueId is optional parameter.
        /// </summary>
        /// <param name="tableType">1-UOM, 2-DataPoint, 3-Dimension</param>
        /// <param name="typeId">this DatapointId is tableType Primary key</param>
        /// <param name="valueId">this DatapointId is translation table primary key</param>
        /// <returns></returns>
        public async Task<IEnumerable<GetTranslationsResponseDto>> GetTranslations(int tableType, long typeId, long? valueId)
        {
            var list = await _valueService.GetMethod(tableType, typeId, valueId);
            return list;
        }
    }
}
