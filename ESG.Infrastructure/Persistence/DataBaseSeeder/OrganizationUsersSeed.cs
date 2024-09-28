using ESG.Domain.Models;
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
                // Organization 1 users
                new OrganizationUser { Id = 1, OrganizationId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 2, OrganizationId = 1, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 3, OrganizationId = 1, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 19, OrganizationId = 1, UserId = 101, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 20, OrganizationId = 1, UserId = 102, CreatedBy = 1, CreatedDate = DateTime.UtcNow },

                // Organization 2 users
                new OrganizationUser { Id = 4, OrganizationId = 2, UserId = 4, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 5, OrganizationId = 2, UserId = 5, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 6, OrganizationId = 2, UserId = 6, CreatedBy = 1, CreatedDate = DateTime.UtcNow },

                // Organization 3 users
                new OrganizationUser { Id = 7, OrganizationId = 3, UserId = 7, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 8, OrganizationId = 3, UserId = 8, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 9, OrganizationId = 3, UserId = 9, CreatedBy = 1, CreatedDate = DateTime.UtcNow },

                // Organization 4 users
                new OrganizationUser { Id = 10, OrganizationId = 4, UserId = 10, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 11, OrganizationId = 4, UserId = 11, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 12, OrganizationId = 4, UserId = 12, CreatedBy = 1, CreatedDate = DateTime.UtcNow },

                // Organization 5 users
                new OrganizationUser { Id = 13, OrganizationId = 5, UserId = 13, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 14, OrganizationId = 5, UserId = 14, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 15, OrganizationId = 5, UserId = 15, CreatedBy = 1, CreatedDate = DateTime.UtcNow },

                // Organization 6 users
                new OrganizationUser { Id = 16, OrganizationId = 6, UserId = 16, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 17, OrganizationId = 6, UserId = 17, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
                new OrganizationUser { Id = 18, OrganizationId = 6, UserId = 18, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
            );

        }
    }
}
