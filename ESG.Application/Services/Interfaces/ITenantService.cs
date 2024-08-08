using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface ITenantService
    {
        Task<Tenant> AddAsync(Tenant tenant);
        Task<Tenant> UpdateAsync(Tenant tenant);
        Task<IEnumerable<Tenant>> GetAll();
        Task<Tenant> GetById(long Id);
        Task<long> Count();
        Task<Tenant> Delete(long Id);
    }
}
