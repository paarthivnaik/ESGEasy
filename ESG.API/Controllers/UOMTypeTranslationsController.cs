﻿using ESG.Application.Dto.UOMTranslations;
using ESG.Application.Dto.UOMTypeTranslations;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{
    public class UOMTypeTranslationsController : BaseController
    {
        private readonly ILogger<UOMTypeTranslationsController> _logger;
        private readonly IUOMTypeTranslationsService _uomTypeTranslationsService;
        public UOMTypeTranslationsController(IUOMTypeTranslationsService uomTypeTranslationsService, ILogger<UOMTypeTranslationsController> logger)
        {
            _logger = logger;
            _uomTypeTranslationsService = uomTypeTranslationsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UOMTypeTranslationsCreateRequestDto value)
        {
            try
            {
                await _uomTypeTranslationsService.Add(value);
                return Ok(new { error = false, errorMsg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

        //[HttpPut("Update")]
        //public async Task<IActionResult> Put([FromBody] UOMTypeTranslationsUpdateRequestDto value)
        //{
        //    await _uomTypeTranslationsService.Update(value);
        //    return Ok();
        //}
    }
}
