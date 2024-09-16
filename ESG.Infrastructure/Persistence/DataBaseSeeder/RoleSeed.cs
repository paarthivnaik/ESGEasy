using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "AdminEE" },
                new Role { Id = 2, Name = "ClientAdmin" },
                new Role { Id = 3, Name = "User" });
        }
    }
}
