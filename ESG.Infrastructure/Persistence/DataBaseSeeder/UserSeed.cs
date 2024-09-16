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
                new User { Id = 101, Password = "password101", SecurityStamp = Guid.NewGuid(), Email = "user101@example.com", FirstName = "John", LastName = "Doe", LanguageId = 1, PhoneNumber = "1234567890", CreatedBy = 1, CreatedDate = DateTime.UtcNow},
                new User { Id = 102, Password = "password102", SecurityStamp = Guid.NewGuid(), Email = "user102@example.com", FirstName = "John", LastName = "Doe", LanguageId = 1, PhoneNumber = "1234567890", CreatedBy = 1, CreatedDate = DateTime.UtcNow},
                
                new User { Id = 1, Password = "password1", SecurityStamp = Guid.NewGuid(), Email = "user1@example.com", FirstName = "John", LastName = "Doe", LanguageId = 1, PhoneNumber = "1234567890", CreatedBy = 1, CreatedDate = DateTime.UtcNow},
                new User { Id = 2, Password = "password2", SecurityStamp = Guid.NewGuid(), Email = "user2@example.com", FirstName = "Jane", LastName = "Smith", LanguageId = 1, PhoneNumber = "0987654321", CreatedBy = 2, CreatedDate = DateTime.UtcNow },
                new User { Id = 3, Password = "password3", SecurityStamp = Guid.NewGuid(), Email = "user3@example.com", FirstName = "Alice", LastName = "Johnson", LanguageId = 1, PhoneNumber = "2345678901", CreatedBy = 3, CreatedDate = DateTime.UtcNow },

                new User { Id = 4, Password = "password4", SecurityStamp = Guid.NewGuid(), Email = "user4@example.com", FirstName = "Bob", LastName = "Brown", LanguageId = 1, PhoneNumber = "3456789012", CreatedBy = 4, CreatedDate = DateTime.UtcNow },
                new User { Id = 5, Password = "password5", SecurityStamp = Guid.NewGuid(), Email = "user5@example.com", FirstName = "Charlie", LastName = "Davis", LanguageId = 1, PhoneNumber = "4567890123", CreatedBy = 5, CreatedDate = DateTime.UtcNow },
                new User { Id = 6, Password = "password6", SecurityStamp = Guid.NewGuid(), Email = "user6@example.com", FirstName = "David", LastName = "Evans", LanguageId =1, PhoneNumber = "5678901234", CreatedBy = 6, CreatedDate = DateTime.UtcNow },

                new User { Id = 7, Password = "password7", SecurityStamp = Guid.NewGuid(), Email = "user7@example.com", FirstName = "Eve", LastName = "Foster", LanguageId = 1, PhoneNumber = "6789012345", CreatedBy = 7, CreatedDate = DateTime.UtcNow },
                new User { Id = 8, Password = "password8", SecurityStamp = Guid.NewGuid(), Email = "user8@example.com", FirstName = "Frank", LastName = "Garcia", LanguageId = 1, PhoneNumber = "7890123456", CreatedBy = 8, CreatedDate = DateTime.UtcNow },
                new User { Id = 9, Password = "password9", SecurityStamp = Guid.NewGuid(), Email = "user9@example.com", FirstName = "Grace", LastName = "Harris", LanguageId = 1, PhoneNumber = "8901234567", CreatedBy = 9, CreatedDate = DateTime.UtcNow },


                new User { Id = 10, Password = "password10", SecurityStamp = Guid.NewGuid(), Email = "user10@example.com", FirstName = "Hank", LastName = "Ivy", LanguageId = 1, PhoneNumber = "9012345678", CreatedBy = 10, CreatedDate = DateTime.UtcNow },
                new User { Id = 11, Password = "password11", SecurityStamp = Guid.NewGuid(), Email = "user11@example.com", FirstName = "Irene", LastName = "James", LanguageId = 1, PhoneNumber = "0123456789", CreatedBy = 11, CreatedDate = DateTime.UtcNow },
                new User { Id = 12, Password = "password12", SecurityStamp = Guid.NewGuid(), Email = "user12@example.com", FirstName = "Jack", LastName = "Kane", LanguageId = 1, PhoneNumber = "1234509876", CreatedBy = 12, CreatedDate = DateTime.UtcNow },

                new User { Id = 13, Password = "password13", SecurityStamp = Guid.NewGuid(), Email = "user13@example.com", FirstName = "Laura", LastName = "Mills", LanguageId = 1, PhoneNumber = "2345610987", CreatedBy = 13, CreatedDate = DateTime.UtcNow   },
                new User { Id = 14, Password = "password14", SecurityStamp = Guid.NewGuid(), Email = "user14@example.com", FirstName = "Mike", LastName = "Nelson", LanguageId = 1, PhoneNumber = "3456721098", CreatedBy = 14, CreatedDate = DateTime.UtcNow },
                new User { Id = 15, Password = "password15", SecurityStamp = Guid.NewGuid(), Email = "user15@example.com", FirstName = "Nina", LastName = "Owen", LanguageId = 1, PhoneNumber = "4567832109", CreatedBy = 15, CreatedDate = DateTime.UtcNow },

                new User { Id = 16, Password = "password16", SecurityStamp = Guid.NewGuid(), Email = "user16@example.com", FirstName = "Oliver", LastName = "Perez", LanguageId = 1, PhoneNumber = "5678943210", CreatedBy = 16, CreatedDate = DateTime.UtcNow },
                new User { Id = 17, Password = "password17", SecurityStamp = Guid.NewGuid(), Email = "user17@example.com", FirstName = "Pam", LastName = "Quinn", LanguageId = 1, PhoneNumber = "6789054321", CreatedBy = 17, CreatedDate = DateTime.UtcNow },
                new User { Id = 18, Password = "password18", SecurityStamp = Guid.NewGuid(), Email = "user18@example.com", FirstName = "Quinn", LastName = "Reed", LanguageId = 1, PhoneNumber = "7890165432", CreatedBy = 18, CreatedDate = DateTime.UtcNow }

            );
        }
    }
}
