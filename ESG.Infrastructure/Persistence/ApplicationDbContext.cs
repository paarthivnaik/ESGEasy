﻿using ESG.Application.Common.Interface;
using ESG.Domain.Common;
using ESG.Domain.Entities;
using ESG.Infrastructure.Persistence.UnitOfMeasureRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<UnitOfMeasureType> UnitOfMeasureTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<DimentionType> DimentionTypes { get; set; }
        public DbSet<Dimentions> Dimentions { get; set; }
        public DbSet<DataPointTypes> DataPointTypes { get; set; }
        public DbSet<DataPointValues> DataPointValues { get; set; }
        public DateTime _curretDateTime { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _curretDateTime = DateTime.UtcNow;
        }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entity in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedBy = 1;//GetCurrentUser
                        entity.Entity.CreatedDate = _curretDateTime;
                        entity.Entity.LastModifiedBy = 1;
                        entity.Entity.LastModifiedDate = _curretDateTime;
                        break;
                    case EntityState.Modified:
                        entity.Entity.LastModifiedBy = 1;
                        entity.Entity.LastModifiedDate = _curretDateTime;
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "Russian", IsoCode = "ru" },
            new Language { Id = 2, Name = "Ukrainian", IsoCode = "uk" },
            new Language { Id = 3, Name = "Belarusian", IsoCode = "be" },
            new Language { Id = 4, Name = "Estonian", IsoCode = "et" },
            new Language { Id = 5, Name = "Latvian", IsoCode = "lv" },
            new Language { Id = 6, Name = "Lithuanian", IsoCode = "lt" },
            new Language { Id = 7, Name = "Georgian", IsoCode = "ka" },
            new Language { Id = 8, Name = "Armenian", IsoCode = "hy" },
            new Language { Id = 9, Name = "Azerbaijani", IsoCode = "az" },
            new Language { Id = 10, Name = "Kazakh", IsoCode = "kk" },
            new Language { Id = 11, Name = "Uzbek", IsoCode = "uz" },
            new Language { Id = 12, Name = "Turkmen", IsoCode = "tk" },
            new Language { Id = 13, Name = "Tajik", IsoCode = "tg" },
            new Language { Id = 14, Name = "Kyrgyz", IsoCode = "ky" },
            new Language { Id = 15, Name = "Moldovan", IsoCode = "mo" },
            new Language { Id = 16, Name = "Tatar", IsoCode = "tt" },
            new Language { Id = 17, Name = "Bashkir", IsoCode = "ba" });

            modelBuilder.Entity<Currency>().HasData(
    new Currency { Id = 1, Name = "US Dollar", CurrencyCode = "USD", ShortText = "USD", LongText = "United States Dollar" },
    new Currency { Id = 2, Name = "Euro", CurrencyCode = "EUR", ShortText = "EUR", LongText = "Euro" },
    new Currency { Id = 3, Name = "Indian Rupee", CurrencyCode = "INR", ShortText = "INR", LongText = "Indian Rupee" },
    new Currency { Id = 4, Name = "British Pound", CurrencyCode = "GBP", ShortText = "GBP", LongText = "British Pound Sterling" },
    new Currency { Id = 5, Name = "Canadian Dollar", CurrencyCode = "CAD", ShortText = "CAD", LongText = "Canadian Dollar" },
    new Currency { Id = 6, Name = "Australian Dollar", CurrencyCode = "AUD", ShortText = "AUD", LongText = "Australian Dollar" },
    new Currency { Id = 7, Name = "Japanese Yen", CurrencyCode = "JPY", ShortText = "JPY", LongText = "Japanese Yen" },
    new Currency { Id = 8, Name = "Swiss Franc", CurrencyCode = "CHF", ShortText = "CHF", LongText = "Swiss Franc" },
    new Currency { Id = 9, Name = "Chinese Yuan", CurrencyCode = "CNY", ShortText = "CNY", LongText = "Chinese Yuan Renminbi" },
    new Currency { Id = 10, Name = "Russian Ruble", CurrencyCode = "RUB", ShortText = "RUB", LongText = "Russian Ruble" }
);

            modelBuilder.Entity<DataPointTypes>().HasData(
    new DataPointTypes { Id = 1, Name = "DatapointType1", ShortText = "T1", LongText = "Type 1", LanguageId = 1, OrganizationId = 1, DimentionId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 2, Name = "DatapointType2", ShortText = "T2", LongText = "Type 2", LanguageId = 1, OrganizationId = 1, DimentionId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 3, Name = "DatapointType3", ShortText = "T3", LongText = "Type 3", LanguageId = 1, OrganizationId = 1, DimentionId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 5, Name = "DatapointType5", ShortText = "T5", LongText = "Type 5", LanguageId = 1, OrganizationId = 1, DimentionId = 2, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 6, Name = "DatapointType6", ShortText = "T6", LongText = "Type 6", LanguageId = 1, OrganizationId = 1, DimentionId = 2, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 7, Name = "DatapointType7", ShortText = "T7", LongText = "Type 7", LanguageId = 1, OrganizationId = 1, DimentionId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 8, Name = "DatapointType8", ShortText = "T8", LongText = "Type 8", LanguageId = 1, OrganizationId = 1, DimentionId = 3, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 9, Name = "DatapointType9", ShortText = "T9", LongText = "Type 9", LanguageId = 1, OrganizationId = 1, DimentionId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 10, Name = "DatapointType10", ShortText = "T10", LongText = "Type 10", LanguageId = 1, OrganizationId = 1, DimentionId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<DataPointValues>().HasData(
    new DataPointValues { Id = 1, Name = "DataPointValue1", DatapointTypeId = 1, IsUOM = false, IsCurrency = true, IsNarrative = false, Value = "Value 1", Purpose = "Purpose 1", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 2, Name = "DataPointValue2", DatapointTypeId = 1, IsUOM = true, IsCurrency = false, IsNarrative = false, Value = "Value 2", Purpose = "Purpose 2", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 3, Name = "DataPointValue3", DatapointTypeId = 1, IsUOM = false, IsCurrency = true, IsNarrative = false, Value = "Value 3", Purpose = "Purpose 3", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 4, Name = "DataPointValue4", DatapointTypeId = 1, IsUOM = false, IsCurrency = false, IsNarrative = true, Value = "Value 4", Purpose = "Purpose 4", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 5, Name = "DataPointValue5", DatapointTypeId = 1, IsUOM = false, IsCurrency = true, IsNarrative = false, Value = "Value 5", Purpose = "Purpose 5", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 6, Name = "DataPointValue6", DatapointTypeId = 1, IsUOM = true, IsCurrency = false, IsNarrative = false, Value = "Value 6", Purpose = "Purpose 6", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 7, Name = "DataPointValue7", DatapointTypeId = 1, IsUOM = false, IsCurrency = true, IsNarrative = false, Value = "Value 7", Purpose = "Purpose 7", LanguageId = 2, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 8, Name = "DataPointValue8", DatapointTypeId = 1, IsUOM = false, IsCurrency = false, IsNarrative = true, Value = "Value 8", Purpose = "Purpose 8", LanguageId = 2, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 9, Name = "DataPointValue9", DatapointTypeId = 1, IsUOM = false, IsCurrency = true, IsNarrative = false, Value = "Value 9", Purpose = "Purpose 9", LanguageId = 2, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 10, Name = "DataPointValue10", DatapointTypeId = 1, IsUOM = true, IsCurrency = false, IsNarrative = false, Value = "Value 10", Purpose = "Purpose 10", LanguageId = 2, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<Dimentions>().HasData(
    new Dimentions { Id = 1, Name = "Dimension1", ShortText = "D1", LongText = "Dimension 1", LanguageId = 1, DimentionTypeId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 2, Name = "Dimension2", ShortText = "D2", LongText = "Dimension 2", LanguageId = 1, DimentionTypeId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 3, Name = "Dimension3", ShortText = "D3", LongText = "Dimension 3", LanguageId = 1, DimentionTypeId = 2, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 4, Name = "Dimension4", ShortText = "D4", LongText = "Dimension 4", LanguageId = 1, DimentionTypeId = 2, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 5, Name = "Dimension5", ShortText = "D5", LongText = "Dimension 5", LanguageId = 1, DimentionTypeId = 2, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 6, Name = "Dimension6", ShortText = "D6", LongText = "Dimension 6", LanguageId = 1, DimentionTypeId = 3, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 7, Name = "Dimension7", ShortText = "D7", LongText = "Dimension 7", LanguageId = 1, DimentionTypeId = 3, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 8, Name = "Dimension8", ShortText = "D8", LongText = "Dimension 8", LanguageId = 1, DimentionTypeId = 4, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 9, Name = "Dimension9", ShortText = "D9", LongText = "Dimension 9", LanguageId = 1, DimentionTypeId = 4, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new Dimentions { Id = 10, Name = "Dimension10", ShortText = "D10", LongText = "Dimension 10", LanguageId = 1, DimentionTypeId = 4, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<DimentionType>().HasData(
    new DimentionType { Id = 1, Name = "DimensionType1", ShortText = "DT1", LongText = "Dimension Type 1", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 2, Name = "DimensionType2", ShortText = "DT2", LongText = "Dimension Type 2", LanguageId = 1, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 3, Name = "DimensionType3", ShortText = "DT3", LongText = "Dimension Type 3", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 4, Name = "DimensionType4", ShortText = "DT4", LongText = "Dimension Type 4", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 5, Name = "DimensionType5", ShortText = "DT5", LongText = "Dimension Type 5", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 6, Name = "DimensionType6", ShortText = "DT6", LongText = "Dimension Type 6", LanguageId = 1, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 7, Name = "DimensionType7", ShortText = "DT7", LongText = "Dimension Type 7", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 8, Name = "DimensionType8", ShortText = "DT8", LongText = "Dimension Type 8", LanguageId = 1, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 9, Name = "DimensionType9", ShortText = "DT9", LongText = "Dimension Type 9", LanguageId = 1, IsHeirarchialDimention = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimentionType { Id = 10, Name = "DimensionType10", ShortText = "DT10", LongText = "Dimension Type 10", LanguageId = 1, IsHeirarchialDimention = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);

            modelBuilder.Entity<UnitOfMeasureType>().HasData(
     new UnitOfMeasureType { Id = 1, Name = "Speed", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
     new UnitOfMeasureType { Id = 2, Name = "Weight", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
     new UnitOfMeasureType { Id = 3, Name = "Amount", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 });

            modelBuilder.Entity<UnitOfMeasure>().HasData(
             new UnitOfMeasure { Id = 4, ShortText = "kg", LongText = "Kilogram", UnitOfMeasureTypeId = 2, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
             new UnitOfMeasure { Id = 5, ShortText = "gm", LongText = "Gram", UnitOfMeasureTypeId = 2, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
             new UnitOfMeasure { Id = 6, ShortText = "ml", LongText = "milliliter", UnitOfMeasureTypeId = 3, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
             new UnitOfMeasure { Id = 7, ShortText = "m/s", LongText = "meterpersecond", UnitOfMeasureTypeId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 },
             new UnitOfMeasure { Id = 8, ShortText = "kmph", LongText = "kmperhour", UnitOfMeasureTypeId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1, OrganizationId = 1 });

            modelBuilder.Entity<Tenant>().HasData(
            new Tenant { Id = 1, Name = "ESG" });

            modelBuilder.Entity<Organization>().HasData(
            new Organization { Id = 1, Name = "ESGOrganization", TenantId = 1 });

            modelBuilder.Entity<User>().HasData(
    new User
    {
        Id = 1,
        Password = Encoding.UTF8.GetBytes("password1"),
        SecurityStamp = Guid.NewGuid(),
        Email = "user1@example.com",
        FirstName = "John",
        LastName = "Doe",
        EmailConfirmed = true,
        PhoneNumber = "1234567890",
        PhoneNumberConfirmed = true,
        LockoutEnabled = false,
        AccessFailedCount = 0,
        Active = true,
        LastLogin = DateTime.UtcNow,
        PasswordExpiry = DateTime.UtcNow.AddMonths(3),
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
        EmailConfirmed = true,
        PhoneNumber = "0987654321",
        PhoneNumberConfirmed = true,
        LockoutEnabled = false,
        AccessFailedCount = 0,
        Active = true,
        LastLogin = DateTime.UtcNow,
        PasswordExpiry = DateTime.UtcNow.AddMonths(3),
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
        EmailConfirmed = true,
        PhoneNumber = "2345678901",
        PhoneNumberConfirmed = true,
        LockoutEnabled = false,
        AccessFailedCount = 0,
        Active = true,
        LastLogin = DateTime.UtcNow,
        PasswordExpiry = DateTime.UtcNow.AddMonths(3),
        CreatedBy = 1,
        CreatedDate = DateTime.UtcNow
    });


            modelBuilder.Entity<OrganizationUser>().HasData(
    new OrganizationUser { Id = 1, OrganizationId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new OrganizationUser { Id = 2, OrganizationId = 1, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new OrganizationUser { Id = 3, OrganizationId = 1, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
    );
            modelBuilder.Entity<Role>().HasData(
    new Role { Id = 1, Name = "AdminEE" },
    new Role { Id = 2, Name = "ClientAdmin" },
    new Role { Id = 3, Name = "User" });

            modelBuilder.Entity<UserRole>().HasData(
     new UserRole { Id = 1, RoleId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
     new UserRole { Id = 2, RoleId = 2, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
     new UserRole { Id = 3, RoleId = 3, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }

     );


            base.OnModelCreating(modelBuilder);
        }

    }
}
