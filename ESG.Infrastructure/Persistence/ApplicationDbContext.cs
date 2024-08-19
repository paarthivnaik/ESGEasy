﻿using ESG.Application.Common.Interface;
using ESG.Domain.Common;
using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ESG.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _curretDateTime = DateTime.UtcNow;
        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<UnitOfMeasureTranslations> UnitOfMeasureTranslations{ get; set; }
        public DbSet<UnitOfMeasureType> UnitOfMeasureTypes { get; set; }
        public DbSet<UnitOfMeasureTypeTranslations> UnitOfMeasureTypeTranslations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<DimensionType> DimensionTypes { get; set; }
        public DbSet<ESG.Domain.Entities.Dimensions> Dimensions { get; set; }
        public DbSet<DataPointTypes> DataPointTypes { get; set; }
        public DbSet<DatapointTypeTranslations> DatapointTypeTranslations { get; set; }
        public DbSet<DataPointValues> DataPointValues { get; set; }
        public DbSet<DatapointValueTranslations> DatapointValueTranslations { get; set; }
        public DbSet<DimensionTypeTranslations> DimensionTypeTranslations { get; set; }
        public DbSet<DimensionTranslations> DimensionTranslations { get; set; }
        public DbSet<Audit> AuditLogs { get; set; }
        public DateTime _curretDateTime { get; set; }

        public async Task<int> SaveChangesAsync()
        {

            try
            {
                var auditEntries = OnBeforeSaveChanges();
                var result = await base.SaveChangesAsync();
                await OnAfterSaveChanges(auditEntries);
                return result;
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or inspect the inner exception
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        private List<AuditEntry> OnBeforeSaveChanges()
        {


            foreach (var entity in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        //entity.Entity.CreatedBy = 1;//GetCurrentUser
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


            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.CreatedBy = 1;//GetCurrentUser

                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }
        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                AuditLogs.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
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
            modelBuilder.Entity<Tenant>().HasData(
            new Tenant { Id = 1, Name = "ESG Global" });

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
            modelBuilder.Entity<Role>().HasData(
    new Role { Id = 1, Name = "AdminEE" },
    new Role { Id = 2, Name = "ClientAdmin" },
    new Role { Id = 3, Name = "User" });

            modelBuilder.Entity<OrganizationUser>().HasData(
   new OrganizationUser { Id = 1, OrganizationId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
   new OrganizationUser { Id = 2, OrganizationId = 1, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
   new OrganizationUser { Id = 3, OrganizationId = 1, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
   );
            modelBuilder.Entity<UserRole>().HasData(
     new UserRole { Id = 1, RoleId = 1, UserId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
     new UserRole { Id = 2, RoleId = 2, UserId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
     new UserRole { Id = 3, RoleId = 3, UserId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
     );

            modelBuilder.Entity<UnitOfMeasureType>().HasData(
     new UnitOfMeasureType { Id = 1, Code = "speed", Name = "Speed", ShortText = "T1", LongText = "Type 1", OrganizationId = 1, State = StateEnum.active, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1 },
     new UnitOfMeasureType { Id = 2, Code = "weight", Name = "Weight", ShortText = "T2", LongText = "Type 2", OrganizationId = 1, State = StateEnum.active, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1 },
     new UnitOfMeasureType { Id = 3, Code = "amount", Name = "Amount", ShortText = "T3", LongText = "Type 3", OrganizationId = 1, State = StateEnum.active, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1 });

            modelBuilder.Entity<UnitOfMeasure>().HasData(
    new UnitOfMeasure { Id = 4, Name = "weight", Code = "weight", ShortText = "kg", LongText = "Kilogram", UnitOfMeasureTypeId = 2, LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
    new UnitOfMeasure { Id = 5, Name = "weight", Code = "weight", ShortText = "gm", LongText = "Gram", UnitOfMeasureTypeId = 2, LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
    new UnitOfMeasure { Id = 6, Name = "amount", Code = "weight", ShortText = "ml", LongText = "milliliter", UnitOfMeasureTypeId = 3, LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
    new UnitOfMeasure { Id = 7, Name = "speed", Code = "weight", ShortText = "m/s", LongText = "meterpersecond", UnitOfMeasureTypeId = 1, LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
    new UnitOfMeasure { Id = 8, Name = "speed", Code = "weight", ShortText = "kmph", LongText = "kmperhour", UnitOfMeasureTypeId = 1, LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 });

            modelBuilder.Entity<UnitOfMeasureTranslations>().HasData(
   new UnitOfMeasureTranslations { Id = 10, Name = "weight", ShortText = "kg", LongText = "Kilogram", UnitOfMeasureId = 4, LanguageId = 1,  CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTranslations { Id = 11, Name = "weight",  ShortText = "gm", LongText = "Gram", UnitOfMeasureId = 4, LanguageId = 2,  CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTranslations { Id = 12, Name = "amount",  ShortText = "ml", LongText = "milliliter", UnitOfMeasureId = 6, LanguageId = 1,  CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTranslations { Id = 13, Name = "speed",  ShortText = "m/s", LongText = "meterpersecond", UnitOfMeasureId = 7, LanguageId = 1,  CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTranslations { Id = 14, Name = "speed",  ShortText = "kmph", LongText = "kmperhour", UnitOfMeasureId = 7, LanguageId = 2,  CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 });

            modelBuilder.Entity<UnitOfMeasureTypeTranslations>().HasData(
   new UnitOfMeasureTypeTranslations { Id = 10, Name = "weight", ShortText = "kg", LongText = "Kilogram", UnitOfMeasureTypeId = 2, LanguageId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTypeTranslations { Id = 11, Name = "weight", ShortText = "gm", LongText = "Gram", UnitOfMeasureTypeId = 2, LanguageId = 2, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTypeTranslations { Id = 12, Name = "amount", ShortText = "ml", LongText = "milliliter", UnitOfMeasureTypeId = 3, LanguageId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTypeTranslations { Id = 13, Name = "speed", ShortText = "m/s", LongText = "meterpersecond", UnitOfMeasureTypeId = 1, LanguageId = 1, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 },
   new UnitOfMeasureTypeTranslations { Id = 14, Name = "speed", ShortText = "kmph", LongText = "kmperhour", UnitOfMeasureTypeId = 1, LanguageId = 2, CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1 });


            modelBuilder.Entity<DataPointTypes>().HasData(
    new DataPointTypes { Id = 99, Name = "DatapointType1", ShortText = "T1", LongText = "Type 1", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 98, Name = "DatapointType2", ShortText = "T2", LongText = "Type 2", LanguageId = 1, OrganizationId = 1, CreatedBy = 2, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 97, Name = "DatapointType3", ShortText = "T3", LongText = "Type 3", LanguageId = 1, OrganizationId = 1, CreatedBy = 3, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 96, Name = "DatapointType5", ShortText = "T5", LongText = "Type 5", LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 95, Name = "DatapointType6", ShortText = "T6", LongText = "Type 6", LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 94, Name = "DatapointType7", ShortText = "T7", LongText = "Type 7", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 93, Name = "DatapointType8", ShortText = "T8", LongText = "Type 8", LanguageId = 1, OrganizationId = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 92, Name = "DatapointType9", ShortText = "T9", LongText = "Type 9", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointTypes { Id = 91, Name = "DatapointType10", ShortText = "T10", LongText = "Type 10", LanguageId = 1, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<DatapointTypeTranslations>().HasData(
    new DatapointTypeTranslations { Id = 101, Name = "DatapointType1", ShortText = "T1", LongText = "Type 1", DatapointTypeId = 99, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 102, Name = "DatapointType1", ShortText = "T2", LongText = "Type 2", DatapointTypeId = 99, LanguageId = 2, CreatedBy = 2, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 103, Name = "DatapointType2", ShortText = "T3", LongText = "Type 3", DatapointTypeId = 99, LanguageId = 3, CreatedBy = 3, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 104, Name = "DatapointType2", ShortText = "T5", LongText = "Type 5", DatapointTypeId = 98, LanguageId = 1, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 105, Name = "DatapointType3", ShortText = "T6", LongText = "Type 6", DatapointTypeId = 98, LanguageId = 2, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 106, Name = "DatapointType3", ShortText = "T7", LongText = "Type 7", DatapointTypeId = 97,LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 107, Name = "DatapointType5", ShortText = "T8", LongText = "Type 8", DatapointTypeId = 96, LanguageId = 1, CreatedDate = DateTime.UtcNow },
    new DatapointTypeTranslations { Id = 108, Name = "DatapointType5", ShortText = "T9", LongText = "Type 9", DatapointTypeId = 96, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);

            modelBuilder.Entity<DataPointValues>().HasData(
    new DataPointValues { Id = 1, Name = "DataPointValue1", DatapointTypeId = 99, IsUOM = false, IsCurrency = true, IsNarrative = false, OrganizationId = 1, Value = "Value 1", Purpose = "Purpose 1", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 2, Name = "DataPointValue2", DatapointTypeId = 99, IsUOM = true, IsCurrency = false, IsNarrative = false, OrganizationId = 1, Value = "Value 2", Purpose = "Purpose 2", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 3, Name = "DataPointValue3", DatapointTypeId = 99, IsUOM = false, IsCurrency = true, IsNarrative = false, OrganizationId = 1, Value = "Value 3", Purpose = "Purpose 3", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 4, Name = "DataPointValue4", DatapointTypeId = 98, IsUOM = false, IsCurrency = false, IsNarrative = true, OrganizationId = 1, Value = "Value 4", Purpose = "Purpose 4", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 5, Name = "DataPointValue5", DatapointTypeId = 98, IsUOM = false, IsCurrency = true, IsNarrative = false, OrganizationId = 1, Value = "Value 5", Purpose = "Purpose 5", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 6, Name = "DataPointValue6", DatapointTypeId = 97, IsUOM = true, IsCurrency = false, IsNarrative = false, OrganizationId = 1, Value = "Value 6", Purpose = "Purpose 6", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 7, Name = "DataPointValue7", DatapointTypeId = 97, IsUOM = false, IsCurrency = true, IsNarrative = false, OrganizationId = 1, Value = "Value 7", Purpose = "Purpose 7", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 8, Name = "DataPointValue8", DatapointTypeId = 97, IsUOM = false, IsCurrency = false, IsNarrative = true, OrganizationId = 1, Value = "Value 8", Purpose = "Purpose 8", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 9, Name = "DataPointValue9", DatapointTypeId = 95, IsUOM = false, IsCurrency = true, IsNarrative = false, OrganizationId = 1, Value = "Value 9", Purpose = "Purpose 9", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DataPointValues { Id = 10, Name = "DataPointValue10", DatapointTypeId = 95, IsUOM = true, IsCurrency = false, IsNarrative = false, OrganizationId = 1, Value = "Value 10", Purpose = "Purpose 10", LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<DatapointValueTranslations>().HasData(
    new DatapointValueTranslations { Id = 101, Name = "DataPointValue1", DatapointValueId = 1, LanguageId = 1,Value = "10m",Purpose = "--", CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 102, Name = "DataPointValue1", DatapointValueId = 1, LanguageId = 2, Value = "10", Purpose = "--", CreatedBy = 2, CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 103, Name = "DataPointValue2", DatapointValueId = 2, LanguageId = 1, Value = "10", Purpose = "--", CreatedBy = 3, CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 104, Name = "DataPointValue2", DatapointValueId = 2, LanguageId = 2, Value = "10", Purpose = "--", CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 105, Name = "DataPointValue3", DatapointValueId = 3, LanguageId = 1, Value = "10", Purpose = "--", CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 106, Name = "DataPointValue3", DatapointValueId = 3, LanguageId = 2, Value = "10", Purpose = "--", CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 107, Name = "DataPointValue5", DatapointValueId = 5, LanguageId = 1, Value = "10", Purpose = "--", CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 108, Name = "DataPointValue5", DatapointValueId = 5, LanguageId = 2, Value = "10", Purpose = "--", CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DatapointValueTranslations { Id = 109, Name = "DataPointValue5", DatapointValueId = 5, LanguageId = 3, Value = "10", Purpose = "--", CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);
            modelBuilder.Entity<DimensionType>().HasData(
    new DimensionType { Id = 50, Name = "DimensionType1",Code ="code", ShortText = "DT1", LongText = "Dimension Type 1", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 51, Name = "DimensionType2", Code = "code", ShortText = "DT2", LongText = "Dimension Type 2", LanguageId = 1, IsHeirarchialDimension = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 52, Name = "DimensionType3", Code = "code", ShortText = "DT3", LongText = "Dimension Type 3", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 53, Name = "DimensionType4", Code = "code", ShortText = "DT4", LongText = "Dimension Type 4", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 54, Name = "DimensionType5", Code = "code", ShortText = "DT5", LongText = "Dimension Type 5", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 55, Name = "DimensionType6", Code = "code", ShortText = "DT6", LongText = "Dimension Type 6", LanguageId = 1, IsHeirarchialDimension = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 56, Name = "DimensionType7", Code = "code", ShortText = "DT7", LongText = "Dimension Type 7", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 57, Name = "DimensionType8", Code = "code", ShortText = "DT8", LongText = "Dimension Type 8", LanguageId = 1, IsHeirarchialDimension = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 58, Name = "DimensionType9", Code = "code", ShortText = "DT9", LongText = "Dimension Type 9", LanguageId = 1, IsHeirarchialDimension = true, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionType { Id = 59, Name = "DimensionType10", Code = "code", ShortText = "DT10", LongText = "Dimension Type 10", LanguageId = 1, IsHeirarchialDimension = false, OrganizationId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);

            modelBuilder.Entity<Dimensions>().HasData(
       new Dimensions
       {
           Id = 100,
           Code = "code",
           Name = "Dimension 1",
           ShortText = "Short 1",
           LongText = "Long Description 1",
           LanguageId = 1,
           DimensionTypeId = 50,
           IsHeirarchialDimension = true,
           OrganizationId = 1
       },
       new Dimensions
       {
           Id = 101,
           Code = "code",
           Name = "Dimension 2",
           ShortText = "Short 2",
           LongText = "Long Description 2",
           LanguageId = 1,
           DimensionTypeId = 50,
           IsHeirarchialDimension = true,
           OrganizationId = 1
       },
       new Dimensions
       {
           Id = 102,
           Code = "code",
           Name = "Dimension 3",
           ShortText = "Short 3",
           LongText = "Long Description 3",
           LanguageId = 1,
           DimensionTypeId = 51,
           IsHeirarchialDimension = true,
           OrganizationId = 1
       },
       new Dimensions
       {
           Id = 103,
           Code = "code",
           Name = "Dimension 4",
           ShortText = "Short 4",
           LongText = "Long Description 4",
           LanguageId = 1,
           DimensionTypeId = 51,
           IsHeirarchialDimension = true,
           OrganizationId = 1
       }
   );
            modelBuilder.Entity<DimensionTranslations>().HasData(
    //new DimensionTranslations { Id = 10, Name = "DimensionType1", ShortText = "DT1", LongText = "Dimension Type 1", DimensionsId = 100, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionTranslations { Id = 1, Name = "Dimension2",  ShortText = "DT2", LongText = "Dimension Type 2", DimensionsId = 100, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionTranslations { Id = 2, Name = "Dimension2", ShortText = "DT3", LongText = "Dimension Type 3", DimensionsId = 100, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionTranslations {Id = 3, Name = "Dimension2", ShortText = "DT4", LongText = "Dimension Type 4", DimensionsId = 101, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    new DimensionTranslations {Id = 4, Name = "Dimension2", ShortText = "DT5", LongText = "Dimension Type 5", DimensionsId = 101, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
    //new DimensionTranslations {Id = 5, Name = "Dimension2", ShortText = "DT6", LongText = "Dimension Type 6", DimensionsId = 102, LanguageId = 3, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    //new DimensionTranslations {Id = 6, Name = "Dimension2", ShortText = "DT7", LongText = "Dimension Type 7", DimensionsId = 102, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    //new DimensionTranslations {Id = 7, Name = "Dimension2", ShortText = "DT8", LongText = "Dimension Type 8", DimensionsId = 103, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    //new DimensionTranslations {Id = 8, Name = "Dimension2", ShortText = "DT9", LongText = "Dimension Type 9", DimensionsId = 103, LanguageId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
    //new DimensionTranslations {Id = 9, Name = "Dimension2", ShortText = "DT10", LongText = "Dimension Type 10", DimensionsId = 103, LanguageId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow }
);

            //        modelBuilder.Entity<DatapointModel>().HasData(
            //    new DatapointModel
            //    {
            //        DimensionsId = 10,
            //        DatapointId = 1,
            //        DimensionsId = 100,
            //        SortingType = SortingTypeEnum.RowType
            //    },
            //    new DatapointModel
            //    {
            //        DimensionsId = 11,
            //        DatapointId = 1,
            //        DimensionsId = 101,
            //        SortingType = SortingTypeEnum.ColumType
            //    },
            //    new DatapointModel
            //    {
            //        DimensionsId = 12,
            //        DatapointId = 1,
            //        DimensionsId = 102,
            //        SortingType = SortingTypeEnum.FilterType
            //    }
            //);
            base.OnModelCreating(modelBuilder);
        }

    }
}
