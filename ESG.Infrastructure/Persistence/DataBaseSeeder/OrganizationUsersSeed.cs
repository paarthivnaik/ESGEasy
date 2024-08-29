using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class OrganizationUsersSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationUser>().HasData(
               new OrganizationUser { Id = 1, OrganizationId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
               new OrganizationUser { Id = 2, OrganizationId = 1, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
               new OrganizationUser { Id = 3, OrganizationId = 1, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
               );
        }
    }
}
