using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class OrganizationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
                   new Organization
                   {
                       Id = 1,
                       Name = "ESG Global",
                       RegistrationId = "REG-001",
                       FirstName = "John",
                       LatsName = "Doe",
                       StreetAddress = "123 Main St",
                       StreetNumber = "456",
                       PostalCode = "12345",
                       Country = "USA",
                       Email = "john.doe@org1.com",
                       TenantId = 1,
                       LanguageId = 1
                   });
        }
    }
}
