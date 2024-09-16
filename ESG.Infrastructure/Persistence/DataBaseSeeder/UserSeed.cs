using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Password = Encoding.UTF8.GetBytes("password1"),
                    SecurityStamp = Guid.NewGuid(),
                    Email = "user1@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    LanguageId = 1,
                    PhoneNumber = "1234567890",
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Password = Encoding.UTF8.GetBytes("password2"),
                    SecurityStamp = Guid.NewGuid(),
                    Email = "user2@example.com",
                    FirstName = "Jane",
                    LastName = "Smith",
                    LanguageId = 1,
                    PhoneNumber = "0987654321",
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 3,
                    Password = Encoding.UTF8.GetBytes("password3"),
                    SecurityStamp = Guid.NewGuid(),
                    Email = "user3@example.com",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    LanguageId = 1,
                    PhoneNumber = "2345678901",
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                });
        }
    }
}
