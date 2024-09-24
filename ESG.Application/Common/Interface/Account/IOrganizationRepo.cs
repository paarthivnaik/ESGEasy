using ESG.Domain.Entities.TenantAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Account
{
    public interface IOrganizationRepo : IGenericRepository<Organization>
    {
        Task<List<OrganizationUser>> GetOrganizationUsers(long id);
    }
}
