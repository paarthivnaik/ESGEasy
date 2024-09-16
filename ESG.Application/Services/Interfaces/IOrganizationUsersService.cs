using ESG.Domain.Entities.TenantAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IOrganizationUsersService
    {
        Task AddAsync(OrganizationUser organizationUsers);
        Task<OrganizationUser> UpdateAsync(OrganizationUser organizationUsers);
        Task<IEnumerable<OrganizationUser>> GetAll();
        Task<OrganizationUser> GetById(long Id);
        Task<long> Count();
        Task<OrganizationUser> Delete(long Id);
    }
}
