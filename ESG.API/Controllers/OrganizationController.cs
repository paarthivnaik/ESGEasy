﻿using ESG.Application.Dto.Organization;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESG.API.Controllers
{

    public class OrganizationController : BaseController
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationService _organizationService;
        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService organizationService)
        {
            _logger = logger;
            _organizationService = organizationService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _organizationService.GetAll();
            return Ok(res);
        }

        [HttpGet("GetOrganizationalUsersByOrgId")]
        public async Task<List<OrganizationUsersResponseDto>> GetOrganizationalUsers(long id)
        {
            var res = await _organizationService.GetOrganizationalUsers(id);
            return res;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(Organization organization)
        //{
        //    await _organizationService.AddAsync(organization);
        //    return Ok();
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Organization organization)
        //{
        //    var res = await _organizationService.UpdateAsync(organization);
        //    return Ok(res);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    await _organizationService.DeleteAsync(id);
        //    return Ok();
        //}
    }
}
