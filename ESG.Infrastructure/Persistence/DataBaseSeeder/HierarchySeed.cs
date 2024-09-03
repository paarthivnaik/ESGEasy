using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public class HierarchySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hierarchy>().HasData(
                new Hierarchy {Id = 1, HierarchyId = 1, DataPointValuesId = 10032 },
                new Hierarchy { Id = 2, HierarchyId = 1, DataPointValuesId = 10033 },
                new Hierarchy { Id = 3, HierarchyId = 1, DataPointValuesId = 10074 },
                new Hierarchy { Id = 4, HierarchyId = 1, DataPointValuesId = 10075 },
                new Hierarchy { Id = 5, HierarchyId = 1, DataPointValuesId = 10249 },
                new Hierarchy { Id = 6, HierarchyId = 1, DataPointValuesId = 10250 },
                new Hierarchy { Id = 7, HierarchyId = 1, DataPointValuesId = 10286 },
                new Hierarchy { Id = 8, HierarchyId = 1, DataPointValuesId = 10287 },
                new Hierarchy { Id = 9, HierarchyId = 1, DataPointValuesId = 10416 },
                new Hierarchy { Id = 10, HierarchyId = 1, DataPointValuesId = 10417 },
                new Hierarchy { Id = 11, HierarchyId = 1, DataPointValuesId = 10583 },
                new Hierarchy { Id = 12, HierarchyId = 1, DataPointValuesId = 10584 },
                new Hierarchy { Id = 13, HierarchyId = 1, DataPointValuesId = 10729 },
                new Hierarchy { Id = 14, HierarchyId = 1, DataPointValuesId = 10730 },

                new Hierarchy { Id = 15, HierarchyId = 2, DataPointValuesId = 10032 },
                new Hierarchy { Id = 16, HierarchyId = 2, DataPointValuesId = 10033 },
                new Hierarchy { Id = 17, HierarchyId = 2, DataPointValuesId = 10074 },
                new Hierarchy { Id = 18, HierarchyId = 2, DataPointValuesId = 10075 },
                new Hierarchy { Id = 19, HierarchyId = 2, DataPointValuesId = 10249 },
                new Hierarchy { Id = 20, HierarchyId = 2, DataPointValuesId = 10250 },
                new Hierarchy { Id = 21, HierarchyId = 2, DataPointValuesId = 10286 },
                new Hierarchy { Id = 22, HierarchyId = 2, DataPointValuesId = 10287 },
                new Hierarchy { Id = 23, HierarchyId = 2, DataPointValuesId = 10416 },
                new Hierarchy { Id = 24, HierarchyId = 2, DataPointValuesId = 10417 },
                new Hierarchy { Id = 25, HierarchyId = 2, DataPointValuesId = 10583 },
                new Hierarchy { Id = 26, HierarchyId = 2, DataPointValuesId = 10584 },
                new Hierarchy { Id = 27, HierarchyId = 2, DataPointValuesId = 10729 },
                new Hierarchy { Id = 28, HierarchyId = 2, DataPointValuesId = 10730 }
                );
            modelBuilder.Entity<OrganizationHeirarchies>().HasData(
                new OrganizationHeirarchies {Id = 1, HierarchyId = 2, OrganizationId = 1,  State = StateEnum.active, CreatedBy = 1, CreatedDate = DateTime.UtcNow, LastModifiedBy = 1, LastModifiedDate = DateTime.UtcNow }
                );
        }
    }
}
