using ESG.Application.Dto.Roles;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task AddAsync(RoleCreationRequestDto role);
        Task UpdateAsync(RoleCreationRequestDto role);
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
