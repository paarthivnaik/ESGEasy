using ESG.Application.Dto.DataModel;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class DatamodelController : BaseController
    {
        private readonly ILogger<UOMController> _logger;
        private readonly IDataModelService _dataModelService;
        public DatamodelController(ILogger<UOMController> logger, IDataModelService dataModelService)
        {
            _logger = logger;
            _dataModelService = dataModelService;
        }
        [HttpPost("CreateDatamodel")]
        public async Task<IActionResult> CreateDataModel(DataModelCreateRequestDto dataModelCreateRequestDto)
        {
            await _dataModelService.CreateDataModel(dataModelCreateRequestDto);
            return Ok();
        }

    }
}
