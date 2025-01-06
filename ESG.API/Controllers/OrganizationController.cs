using ESG.Application.Dto.Organization;
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

        [HttpPost("CreateOrEditOrg")]
        public async Task<IActionResult> Post(OrganizationCreateDto organizationCreateDto)
        {            
            try
            {
                if (organizationCreateDto.Id > 0)
                {
                    await _organizationService.AddAsync(organizationCreateDto);
                    return Ok(new { error = false, errorMsg = "2" });
                }
                await _organizationService.AddAsync(organizationCreateDto);
                return Ok(new { error = false, errorMsg = "1" });

            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Organization organization)
        //{
        //    var res = await _organizationService.UpdateAsync(organization);
        //    return Ok(res);
        //}

        [HttpPatch("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _organizationService.Delete(id);
                return Ok(new { error = false, errorMsg = "Deleted Successfully" });
            }
            catch(Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
            
        }
    }
}