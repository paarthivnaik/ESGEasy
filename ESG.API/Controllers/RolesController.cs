using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ESG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService  _roleService;
        public RolesController(ILogger<RolesController> logger, IRoleService  roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
             return await _roleService.GetAll();
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<Role> Get(int id)
        {
            return await _roleService.GetById(id);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task Post([FromBody] Role value)
        {
            await _roleService.AddAsync(value);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public async Task<Role> Put([FromBody] Role value)
        {
            var res = await _roleService.UpdateAsync(value);
            return res;
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _roleService.Delete(id);
            return res;
        }
    }
}
