using ESG.Application.Common.Interface.Account;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.AccountsRepo
{
    public class UsersRepo : GenericRepository<User>, IUsersRepo
    {
        private readonly ApplicationDbContext _context;
        public UsersRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
