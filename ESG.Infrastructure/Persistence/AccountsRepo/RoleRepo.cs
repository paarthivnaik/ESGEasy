﻿using ESG.Application.Common.Interface.Account;
using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.AccountsRepo
{
    public class RoleRepo : GenericRepository<Role>, IRoleRepo
    {
        private readonly ApplicationDbContext _context;
        public RoleRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
