using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class TenantSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { Id = 1, Name = "ESG Global" });
        }
    }
}
