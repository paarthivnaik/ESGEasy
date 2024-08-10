using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(UserDto user);
        Task<User> Update(UserDto user);
        Task<User> UpdatePassword(UserDto user);
        Task<User> GetUser(long userId);
        Task<User> Delete(long Id);
    }
}
