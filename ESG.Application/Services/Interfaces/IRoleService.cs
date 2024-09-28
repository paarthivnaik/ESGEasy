using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task AddAsync(Role role);
        Task<Role> UpdateAsync(Role role);
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
