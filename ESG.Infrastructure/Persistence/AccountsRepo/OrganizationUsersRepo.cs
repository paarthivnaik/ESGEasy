using ESG.Application.Common.Interface.Account;
using ESG.Domain.Models;

namespace ESG.Infrastructure.Persistence.Account
{
    public class OrganizationUsersRepo : GenericRepository<OrganizationUser>, IOrganizationUsersRepo
    {
        private readonly ApplicationDbContext _context;
        public OrganizationUsersRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
