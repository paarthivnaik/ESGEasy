using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class UserRolesSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, RoleId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 2, RoleId = 2, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 3, RoleId = 3, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
                );
        }
    }
}
