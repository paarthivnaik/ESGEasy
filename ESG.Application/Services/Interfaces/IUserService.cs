using ESG.Application.Dto.User;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> GetUserById(long userId);
        Task<UserDetailsResponeDto> GetUserDetails(long userId);
        Task<List<long>> GetUserOrganizations(long userId);
        Task Create(UserCreationRequestDto user);
        Task<string> UserLogin(UserLogInRequestDto userLogInRequestDto);
        Task<User> Update(UserCreationRequestDto user);
        Task<User> UpdatePassword(UserCreationRequestDto user);
        Task<User> Delete(long Id);
    }
}
