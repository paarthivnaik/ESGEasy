using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IUserRoles
    {
        Task Create(UserRole user);
        Task<UserRole> Update(UserRole user);
        Task<IEnumerable<UserRole>> GetAll();
        Task<UserRole> GetUserRolesByRoleId(long roleId);
        Task<UserRole> GetRolesByUserId(long userId);
        Task<UserRole> Delete(long Id);
    }
}
