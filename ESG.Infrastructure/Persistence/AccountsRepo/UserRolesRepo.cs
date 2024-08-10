using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.Account;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.AccountsRepo
{
    public class UserRolesRepo : GenericRepository<UserRole>, IUserRolesRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRolesRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
