using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.Account
{
    public interface IUsersRepo : IGenericRepository<User>
    {
        Task<string> GenerateToken(long userId,string esmail, long? organizationId, long? roleId);
        Task<User?> GetUserDetails(long userId);
        Task<IEnumerable<OrganizationUser>> GetOrganizatinalUsers(long organizationId);
    }
}
