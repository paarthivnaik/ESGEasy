 using ESG.Application;
using ESG.Application.Dto.User;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
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
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserResponseDto>> Get()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("GetUserOrganizations")]
        public async Task<List<long>> GetUserOrganizations(long id)
        {
            return await _userService.GetUserOrganizations(id);
        }
        [HttpGet("GetUserDetails")]
        public async Task<UserDetailsResponeDto> GetUserDetails(long id)
        {
            return await _userService.GetUserDetails(id);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserCreationRequestDto user)
        {
           await _userService.Create(user);
            return Ok(200);
        }
        [HttpPost("UserLogIn")]
        public async Task<string> UserLogIn(UserLogInRequestDto user)
        {
            var token = await _userService.UserLogin(user);
            return token;
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserCreationRequestDto user)
        {
            await _userService.Update(user);
            return(Ok());
        }

    }
}
