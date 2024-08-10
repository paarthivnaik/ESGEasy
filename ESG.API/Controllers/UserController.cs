using ESG.Application;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ESG.API.Controllers
{

    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService  _userService;
        public UserController(ILogger<UserController> logger, IUserService  userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserDto user)
        {
           await _userService.Create(user);
            return Ok(200);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserDto user)
        {
            await _userService.Update(user);
            return(Ok());
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.Delete(id);
            return (Ok());
        }
    }
}
