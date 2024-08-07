using ESG.Application.Common.Interface;
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
        public DbSet<ESG.Domain.Entities.UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<ESG.Domain.Entities.UnitOfMeasureType> UnitOfMeasureTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
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
            base.OnModelCreating(modelBuilder);
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
            new Language { Id = 17, Name = "Bashkir", IsoCode = "ba" },
            new Language { Id = 18, Name = "Chuvash", IsoCode = "cv" },
            new Language { Id = 19, Name = "Chechen", IsoCode = "ce" },
            new Language { Id = 20, Name = "Ingush", IsoCode = "inh" },
            new Language { Id = 21, Name = "Buryat", IsoCode = "bua" },
            new Language { Id = 22, Name = "Kalmyk", IsoCode = "xal" },
            new Language { Id = 23, Name = "Mordvin", IsoCode = "mdf" },
            new Language { Id = 24, Name = "Mari", IsoCode = "chm" },
            new Language { Id = 25, Name = "Udmurt", IsoCode = "udm" },
            new Language { Id = 26, Name = "Komi", IsoCode = "kv" },
            new Language { Id = 27, Name = "Yakut", IsoCode = "sah" }
        );
            modelBuilder.Entity<Domain.Entities.UnitOfMeasureType>().HasData(
             new Domain.Entities.UnitOfMeasureType { Id = 1, Name = "Kilogram", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1,LanguageId=1 },
             new Domain.Entities.UnitOfMeasureType { Id = 2, Name = "Gram", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1 },
             new Domain.Entities.UnitOfMeasureType { Id = 3, Name = "Liter", CreatedDate = DateTime.UtcNow, CreatedBy = 1, LastModifiedDate = DateTime.UtcNow, LastModifiedBy = 1, LanguageId = 1 }
         );
            
            modelBuilder.Entity<Tenant>().HasData(
              new Tenant
              {
                  Id = 1,
                  Name = "ESG"
              }
          );

            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    Name = "ESG",
                    TenantId = 1
                }
            );
        }

    }
}
