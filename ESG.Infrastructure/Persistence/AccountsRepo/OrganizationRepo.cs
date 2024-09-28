using ESG.Application.Common.Interface.Account;
using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Account
{
    public class OrganizationRepo : GenericRepository<Organization>, IOrganizationRepo
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<OrganizationUser>> GetOrganizationUsers(long id)
        {
            var org = await _context.OrganizationUsers
                .AsNoTracking()
                .Include(x => x.User)
                .Where(o => o.OrganizationId == id)
                .ToListAsync();
            return org;
        }
    }
}
