using ESG.Domain.Models;
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
                new UserRole { Id = 1, RoleId = 2, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 2, RoleId = 3, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 3, RoleId = 3, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 4, RoleId = 2, UserId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 5, RoleId = 3, UserId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 6, RoleId = 3, UserId = 6, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 7, RoleId = 2, UserId = 7, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 8, RoleId = 3, UserId = 8, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 9, RoleId = 3, UserId = 9, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 10, RoleId = 2, UserId = 10, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 11, RoleId = 3, UserId = 11, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 12, RoleId = 3, UserId = 12, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 13, RoleId = 2, UserId = 13, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 14, RoleId = 3, UserId = 14, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 15, RoleId = 3, UserId = 15, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 16, RoleId = 2, UserId = 16, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 17, RoleId = 3, UserId = 17, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 18, RoleId = 3, UserId = 18, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 19, RoleId = 1, UserId = 101, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new UserRole { Id = 20, RoleId = 1, UserId = 102, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
                );
        }
    }
}
