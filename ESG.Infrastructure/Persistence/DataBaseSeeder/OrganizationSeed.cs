﻿using ESG.Domain.Models;
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
                new Organization { Id = 1, Name = "ESG Global", RegistrationId = "REG-001", FirstName = "John", LatsName = "Doe", StreetAddress = "123 Main St", StreetNumber = "456", PostalCode = "12345", Country = "USA", Email = "john.doe@org1.com", TenantId = 1, LanguageId = 1 },
                new Organization { Id = 2, Name = "Green Future", RegistrationId = "REG-002", FirstName = "Jane", LatsName = "Smith", StreetAddress = "456 Oak St", StreetNumber = "789", PostalCode = "67890", Country = "Canada", Email = "jane.smith@org2.com", TenantId = 1, LanguageId = 1 },
                new Organization { Id = 3, Name = "EcoTech", RegistrationId = "REG-003", FirstName = "Alice", LatsName = "Johnson", StreetAddress = "789 Pine St", StreetNumber = "101", PostalCode = "11223", Country = "UK", Email = "alice.johnson@org3.com", TenantId = 1, LanguageId = 1 },
                new Organization { Id = 4, Name = "Sustainable Solutions", RegistrationId = "REG-004", FirstName = "Bob", LatsName = "Brown", StreetAddress = "101 Elm St", StreetNumber = "202", PostalCode = "33445", Country = "Germany", Email = "bob.brown@org4.com", TenantId = 2, LanguageId = 1 },
                new Organization { Id = 5, Name = "CarbonFree", RegistrationId = "REG-005", FirstName = "Charlie", LatsName = "Davis", StreetAddress = "202 Birch St", StreetNumber = "303", PostalCode = "55667", Country = "Australia", Email = "charlie.davis@org5.com", TenantId = 2, LanguageId = 1 },
                new Organization { Id = 6, Name = "CleanEnergy", RegistrationId = "REG-006", FirstName = "David", LatsName = "Evans", StreetAddress = "303 Cedar St", StreetNumber = "404", PostalCode = "77889", Country = "India", Email = "david.evans@org6.com", TenantId = 2, LanguageId = 1 },
                new Organization { Id = 7, Name = "FTH", RegistrationId = "REG-007", FirstName = "David", LatsName = "Evans", StreetAddress = "303 Cedar St", StreetNumber = "404", PostalCode = "77889", Country = "India", Email = "davidee.evans@org6.com", TenantId = 2, LanguageId = 1 }
            );
        }
    }
}
