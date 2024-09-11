using ESG.Application.Common.Interface;
using ESG.Domain.Common;
using ESG.Domain.Entities;
using ESG.Infrastructure.Persistence.DataBaseSeeder;
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
        public DbSet<Hierarchy> Hierarchy { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Standard> Standard { get; set; }
        public DbSet<DisclosureRequirement> DisclosureRequirement { get; set; }
        public DbSet<OrganizationHeirarchies> OrganizationHeirarchies { get; set; }
        public DbSet<ESG.Domain.Entities.DataModel> DataModels { get; set; }
        public DbSet<ModelDimensionTypes> ModelDimensionTypes { get; set; }
        public DbSet<ModelDimensionValues> ModelDimensionValues { get; set; }
        public DbSet<ModelDatapoints> ModelDatapoints { get; set; }
        public DbSet<ModelConfiguration> ModelConfiguration { get; set; }
        public DbSet<ModelFilterCombinations> ModelFilterCombinations    { get; set; }
        public DbSet<ModelFilterCombinationalValues> ModelFilterCombinationalValues    { get; set; }
        public DbSet<DataModelValues> DataModelValues    { get; set; }
        public DbSet<DataModelFilters> DataModelFilters    { get; set; }
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
            base.OnModelCreating(modelBuilder);
            CurrencySeed.Seed(modelBuilder);
            DataPointSeed.Seed(modelBuilder);
            DimensionsSeed.Seed(modelBuilder);
            DisclosureRequirementSeed.Seed(modelBuilder);
            LanguageSeed.Seed(modelBuilder);
            OrganizationSeed.Seed(modelBuilder);
            OrganizationUsersSeed.Seed(modelBuilder);
            RoleSeed.Seed(modelBuilder);
            StandardSeed.Seed(modelBuilder);
            TenantSeed.Seed(modelBuilder);
            TopicSeed.Seed(modelBuilder);
            UnitOfMeasureSeed.Seed(modelBuilder);
            UserRolesSeed.Seed(modelBuilder);
            UserSeed.Seed(modelBuilder);
            DataModelSeeder.Seed(modelBuilder);
            HierarchySeed.Seed(modelBuilder);
        }

    }
}
