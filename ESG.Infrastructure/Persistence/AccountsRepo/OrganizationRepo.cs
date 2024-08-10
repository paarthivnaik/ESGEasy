using ESG.Application.Common.Interface.Account;
using ESG.Domain.Entities;
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
    }
}
