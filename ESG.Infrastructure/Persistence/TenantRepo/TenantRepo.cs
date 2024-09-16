using ESG.Application.Common.Interface.Tenants;
using ESG.Domain.Entities.TenantAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.TenantRepo
{
    public class TenantRepo : GenericRepository<Tenant>, ITenant
    {
        private readonly ApplicationDbContext _context;
        public TenantRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
