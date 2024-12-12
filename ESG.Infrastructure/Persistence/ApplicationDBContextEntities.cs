using ESG.Domain.Models;
using ESG.Infrastructure.Persistence.DataBaseSeeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence
{
    public partial class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Amendment> Amendments { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<ESG.Domain.Models.DataModel> DataModels { get; set; }

        public virtual DbSet<DataModelFilter> DataModelFilters { get; set; }
        public virtual DbSet<DataModelValue> DataModelValues { get; set; }

        public virtual DbSet<DataPointType> DataPointType { get; set; }

        public virtual DbSet<DataPointValue> DataPointValue { get; set; }

        public virtual DbSet<DatapointTypeTranslation> DatapointTypeTranslations { get; set; }

        public virtual DbSet<DatapointValueTranslation> DatapointValueTranslations { get; set; }
        public virtual DbSet<ESG.Domain.Models.Dimension> Dimensions { get; set; }

        public virtual DbSet<DimensionTranslation> DimensionTranslations { get; set; }

        public virtual DbSet<DimensionType> DimensionTypes { get; set; }

        public virtual DbSet<ESG.Domain.Models.DimensionTypeTranslation> DimensionTypeTranslations { get; set; }

        public virtual DbSet<DisclosureRequirement> DisclosureRequirements { get; set; }

        public virtual DbSet<Hierarchy> Hierarchies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<ModelConfiguration> ModelConfigurations { get; set; }

        public virtual DbSet<ModelDatapoint> ModelDatapoints { get; set; }

        public virtual DbSet<ModelDimensionType> ModelDimensionTypes { get; set; }

        public virtual DbSet<ModelDimensionValue> ModelDimensionValues { get; set; }

        public virtual DbSet<ModelFilterCombination> ModelFilterCombinations { get; set; }

        public virtual DbSet<ModelFilterCombinationalValue> ModelFilterCombinationalValues { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationHeirarchy> OrganizationHeirarchies { get; set; }

        public virtual DbSet<OrganizationUser> OrganizationUsers { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<SampleModelFilterCombinationValue> SampleModelFilterCombinationValues { get; set; }

        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public virtual DbSet<UnitOfMeasureTranslation> UnitOfMeasureTranslations { get; set; }

        public virtual DbSet<UnitOfMeasureType> UnitOfMeasureTypes { get; set; }

        public virtual DbSet<UnitOfMeasureTypeTranslation> UnitOfMeasureTypeTranslations { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Database=ESGEasy;Username=postgres;Password=root;Include Error Detail=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingCreation(modelBuilder);
            modelBuilder.Entity<Amendment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Amendments_pkey");

                entity.HasIndex(e => e.FilterCombinationId, "fki_FK_Amendments1-FilterCombinationId");

                entity.HasIndex(e => e.DatapointId, "fki_FK_Amendments_DataPointValuesId");

                entity.HasIndex(e => e.OrganizationId, "fki_FK_Amendments_Organization_OrganizationId");

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.HasOne(d => d.Datapoint).WithMany(p => p.Amendments)
                    .HasForeignKey(d => d.DatapointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Amendments_DataPointValuesId");

                entity.HasOne(d => d.FilterCombination).WithMany(p => p.Amendments)
                    .HasForeignKey(d => d.FilterCombinationId)
                    .HasConstraintName("FK_Amendments1-FilterCombinationId");

                entity.HasOne(d => d.Organization).WithMany(p => p.Amendments)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Amendments_Organization_OrganizationId");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.HasIndex(e => e.Id, "idx_currency_id");
            });

            modelBuilder.Entity<ESG.Domain.Models.DataModel>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_DataModels_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_datamodels_id");

                entity.HasOne(d => d.Organization).WithMany(p => p.DataModels).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<DataModelFilter>(entity =>
            {
                entity.HasIndex(e => e.DimensionTypeId, "IX_DataModelFilters_DimensionTypeId");

                entity.HasIndex(e => e.FilterId, "IX_DataModelFilters_FilterId");

                entity.HasIndex(e => e.ModelConfigurationId, "IX_DataModelFilters_ModelConfigurationId");

                entity.HasIndex(e => e.Id, "idx_datamodelfilters_id");

                entity.HasOne(d => d.DimensionType).WithMany(p => p.DataModelFilterDimensionTypes).HasForeignKey(d => d.DimensionTypeId);

                entity.HasOne(d => d.Filter).WithMany(p => p.DataModelFilterFilters).HasForeignKey(d => d.FilterId);

                entity.HasOne(d => d.ModelConfiguration).WithMany(p => p.DataModelFilters).HasForeignKey(d => d.ModelConfigurationId);
            });

            modelBuilder.Entity<DataModelValue>(entity =>
            {
                entity.HasIndex(e => e.AccountableUserId, "IX_DataModelValues_AccountableUserId");

                entity.HasIndex(e => e.ColumnId, "IX_DataModelValues_ColumnId");

                entity.HasIndex(e => e.CombinationId, "IX_DataModelValues_CombinationId");

                entity.HasIndex(e => e.ResponsibleUserId, "IX_DataModelValues_ResponsibleUserId");

                entity.HasIndex(e => e.RowId, "IX_DataModelValues_RowId");

                entity.HasIndex(e => e.DataModelId, "fki_FK_DataModelValues_DataModel_DataModelId");

                entity.HasIndex(e => e.Consult, "fki_FK_DataModelValues_Users_Consult");

                entity.HasIndex(e => e.Inform, "fki_FK_DataModelValues_Users_Inform");

                entity.HasIndex(e => e.DataPointValuesId, "fki_FK_DataPointValues_DatapointValuesId");

                entity.HasIndex(e => e.DataModelId, "idx_datamodelvalues_datamodel_datamodelid");

                entity.HasIndex(e => e.DataPointValuesId, "idx_datamodelvalues_datapointvaluesid");

                entity.HasIndex(e => e.Id, "idx_datamodelvalues_id");

                entity.HasIndex(e => new { e.DataModelId, e.ResponsibleUserId }, "idx_datamodelvalues_modelid_userid");

                entity.HasIndex(e => new { e.DataModelId, e.ResponsibleUserId, e.DataPointValuesId }, "idx_datamodelvalues_modelid_userid_datapoint");

                entity.HasIndex(e => new { e.RowId, e.ColumnId, e.CombinationId, e.DataPointValuesId }, "unq_contraint_oncombinational_datapoint").IsUnique();

                entity.HasOne(d => d.AccountableUser).WithMany(p => p.DataModelValueAccountableUsers).HasForeignKey(d => d.AccountableUserId);

                entity.HasOne(d => d.Column).WithMany(p => p.DataModelValueColumns).HasForeignKey(d => d.ColumnId);

                entity.HasOne(d => d.Combination).WithMany(p => p.DataModelValues)
                    .HasForeignKey(d => d.CombinationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ConsultNavigation).WithMany(p => p.DataModelValueConsultNavigations).HasForeignKey(d => d.Consult);

                entity.HasOne(d => d.DataModel).WithMany(p => p.DataModelValues)
                    .HasForeignKey(d => d.DataModelId)
                    .HasConstraintName("FK_DataModelValues_DataModel_DataModelId");

                entity.HasOne(d => d.DataPointValues).WithMany(p => p.DataModelValues)
                    .HasForeignKey(d => d.DataPointValuesId)
                    .HasConstraintName("FK_DataPointValues_DatapointValuesId");

                entity.HasOne(d => d.InformNavigation).WithMany(p => p.DataModelValueInformNavigations).HasForeignKey(d => d.Inform);

                entity.HasOne(d => d.ResponsibleUser).WithMany(p => p.DataModelValueResponsibleUsers).HasForeignKey(d => d.ResponsibleUserId);

                entity.HasOne(d => d.Row).WithMany(p => p.DataModelValueRows).HasForeignKey(d => d.RowId);
            });

            modelBuilder.Entity<DataPointType>(entity =>
            {
                entity.ToTable("DataPointType");

                entity.HasIndex(e => e.LanguageId, "IX_DataPointTypes_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_DataPointTypes_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_datapointtypes_id");

                entity.HasOne(d => d.Language).WithMany(p => p.DataPointTypes).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.DataPointTypes).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<DataPointValue>(entity =>
            {
                entity.ToTable("DataPointValue");

                entity.HasIndex(e => e.CurrencyId, "IX_DataPointValues_CurrencyId");

                entity.HasIndex(e => e.DatapointTypeId, "IX_DataPointValues_DatapointTypeId");

                entity.HasIndex(e => e.DisclosureRequirementId, "IX_DataPointValues_DisclosureRequirementId");

                entity.HasIndex(e => e.LanguageId, "IX_DataPointValues_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_DataPointValues_OrganizationId");

                entity.HasIndex(e => e.UnitOfMeasureId, "IX_DataPointValues_UnitOfMeasureId");

                entity.HasIndex(e => e.UserId, "IX_DataPointValues_UserId");

                entity.HasIndex(e => e.Id, "idx_datapointvalues_id");

                entity.HasOne(d => d.Currency).WithMany(p => p.DataPointValues).HasForeignKey(d => d.CurrencyId);

                entity.HasOne(d => d.DatapointType).WithMany(p => p.DataPointValues).HasForeignKey(d => d.DatapointTypeId);

                entity.HasOne(d => d.DisclosureRequirement).WithMany(p => p.DataPointValues)
                    .HasForeignKey(d => d.DisclosureRequirementId)
                    .HasConstraintName("FK_DataPointValues_DisclosureRequirement_DisclosureRequirement~");

                entity.HasOne(d => d.Language).WithMany(p => p.DataPointValues).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.DataPointValues).HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.DataPointValues).HasForeignKey(d => d.UnitOfMeasureId);

                entity.HasOne(d => d.User).WithMany(p => p.DataPointValues).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<DatapointTypeTranslation>(entity =>
            {
                entity.HasIndex(e => new { e.DatapointTypeId, e.LanguageId }, "IX_DatapointTypeTranslations_DatapointTypeId_LanguageId").IsUnique();

                entity.HasIndex(e => e.LanguageId, "IX_DatapointTypeTranslations_LanguageId");

                entity.HasOne(d => d.DatapointType).WithMany(p => p.DatapointTypeTranslations).HasForeignKey(d => d.DatapointTypeId);

                //entity.HasOne(d => d.DatapointTypeNavigation).WithMany(p => p.DatapointTypeTranslations).HasForeignKey(d => d.DatapointTypeId);

                entity.HasOne(d => d.Language).WithMany(p => p.DatapointTypeTranslations).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<DatapointValueTranslation>(entity =>
            {
                entity.HasIndex(e => new { e.DatapointValueId, e.LanguageId }, "IX_DatapointValueTranslations_DatapointValueId_LanguageId").IsUnique();

                entity.HasIndex(e => e.LanguageId, "IX_DatapointValueTranslations_LanguageId");

                entity.HasOne(d => d.DatapointValue).WithMany(p => p.DatapointValueTranslations).HasForeignKey(d => d.DatapointValueId);

                entity.HasOne(d => d.Language).WithMany(p => p.DatapointValueTranslations).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<ESG.Domain.Models.Dimension>(entity =>
            {
                entity.HasIndex(e => e.DimensionTypeId, "IX_Dimensions_DimensionTypeId");

                entity.HasIndex(e => e.LanguageId, "IX_Dimensions_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_Dimensions_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_dimensions_id");

                entity.HasOne(d => d.DimensionType).WithMany(p => p.Dimensions).HasForeignKey(d => d.DimensionTypeId);

                entity.HasOne(d => d.Language).WithMany(p => p.Dimensions).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.Dimensions).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<DimensionTranslation>(entity =>
            {
                entity.HasKey(e => new { e.DimensionsId, e.LanguageId });

                entity.HasIndex(e => e.LanguageId, "IX_DimensionTranslations_LanguageId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Dimensions).WithMany(p => p.DimensionTranslations).HasForeignKey(d => d.DimensionsId);

                entity.HasOne(d => d.Language).WithMany(p => p.DimensionTranslations).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<DimensionType>(entity =>
            {
                entity.HasIndex(e => e.LanguageId, "IX_DimensionTypes_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_DimensionTypes_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_dimensiotypess_id");

                entity.HasOne(d => d.Language).WithMany(p => p.DimensionTypes).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.DimensionTypes).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<DimensionTypeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.DimensionTypeId, e.LanguageId });

                entity.HasIndex(e => e.LanguageId, "IX_DimensionTypeTranslations_LanguageId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.DimensionType).WithMany(p => p.DimensionTypeTranslations).HasForeignKey(d => d.DimensionTypeId);

                entity.HasOne(d => d.Language).WithMany(p => p.DimensionTypeTranslations).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<DisclosureRequirement>(entity =>
            {
                entity.ToTable("DisclosureRequirement");

                entity.HasIndex(e => e.LanguageId, "IX_DisclosureRequirement_LanguageId");

                entity.HasIndex(e => e.StandardId, "IX_DisclosureRequirement_StandardId");

                entity.HasIndex(e => e.Id, "idx_disclosurerequirement_id");

                entity.HasOne(d => d.Language).WithMany(p => p.DisclosureRequirements).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Standard).WithMany(p => p.DisclosureRequirements).HasForeignKey(d => d.StandardId);
            });

            modelBuilder.Entity<Hierarchy>(entity =>
            {
                entity.ToTable("Hierarchy");

                entity.HasIndex(e => e.DataPointValuesId, "IX_Hierarchy_DataPointValuesId");

                entity.HasIndex(e => e.HierarchyId, "idx_hierarchy_id");

                entity.HasOne(d => d.DataPointValues).WithMany(p => p.Hierarchies).HasForeignKey(d => d.DataPointValuesId);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_Languages_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_languages_id");

                entity.HasOne(d => d.Organization).WithMany(p => p.Languages).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<ModelConfiguration>(entity =>
            {
                entity.ToTable("ModelConfiguration");

                entity.HasIndex(e => e.ColumnId, "IX_ModelConfiguration_ColumnId");

                entity.HasIndex(e => e.DataModelId, "IX_ModelConfiguration_DataModelId");

                entity.HasIndex(e => e.RowId, "IX_ModelConfiguration_RowId");

                entity.HasIndex(e => e.Id, "idx_modelconfiguration_id");

                entity.HasIndex(e => new { e.DataModelId, e.ViewType }, "idx_modelid_viewtype");

                entity.HasOne(d => d.Column).WithMany(p => p.ModelConfigurationColumns).HasForeignKey(d => d.ColumnId);

                entity.HasOne(d => d.DataModel).WithMany(p => p.ModelConfigurations).HasForeignKey(d => d.DataModelId);

                entity.HasOne(d => d.Row).WithMany(p => p.ModelConfigurationRows).HasForeignKey(d => d.RowId);
            });

            modelBuilder.Entity<ModelDatapoint>(entity =>
            {
                entity.HasIndex(e => e.DataModelId, "IX_ModelDatapoints_DataModelId");

                entity.HasIndex(e => e.DatapointValuesId, "IX_ModelDatapoints_DatapointValuesId");

                entity.HasIndex(e => e.Id, "idx_modeldatapoints_id");

                entity.HasOne(d => d.DataModel).WithMany(p => p.ModelDatapoints).HasForeignKey(d => d.DataModelId);

                entity.HasOne(d => d.DatapointValues).WithMany(p => p.ModelDatapoints).HasForeignKey(d => d.DatapointValuesId);
            });

            modelBuilder.Entity<ModelDimensionType>(entity =>
            {
                entity.HasIndex(e => e.DataModelId, "IX_ModelDimensionTypes_DataModelId");

                entity.HasIndex(e => e.DimensionTypeId, "fki_FK_ModelDimensionTypes_DimensionType_DimensionTypeId");

                entity.HasIndex(e => e.Id, "idx_modeldimensiontypes_id");

                entity.HasOne(d => d.DataModel).WithMany(p => p.ModelDimensionTypes).HasForeignKey(d => d.DataModelId);

                entity.HasOne(d => d.DimensionType).WithMany(p => p.ModelDimensionTypes)
                    .HasForeignKey(d => d.DimensionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelDimensionTypes_DimensionType_DimensionTypeId");
            });

            modelBuilder.Entity<ModelDimensionValue>(entity =>
            {
                entity.HasIndex(e => e.DimensionsId, "IX_ModelDimensionValues_DimensionsId");

                entity.HasIndex(e => e.ModelDimensionTypesId, "IX_ModelDimensionValues_ModelDimensionTypesId");

                entity.HasIndex(e => e.Id, "idx_modeldimensionvalues_id");

                entity.HasOne(d => d.Dimensions).WithMany(p => p.ModelDimensionValues).HasForeignKey(d => d.DimensionsId);

                entity.HasOne(d => d.ModelDimensionTypes).WithMany(p => p.ModelDimensionValues)
                    .HasForeignKey(d => d.ModelDimensionTypesId)
                    .HasConstraintName("FK_ModelDimensionValues_ModelDimensionTypes_ModelDimensionType~");
            });

            modelBuilder.Entity<ModelFilterCombination>(entity =>
            {
                entity.HasIndex(e => e.DataModelId, "fki_FK_DataModel_DataModelId");

                entity.HasIndex(e => e.Id, "idx_modelfiltercombinations_id");

                entity.HasOne(d => d.DataModel).WithMany(p => p.ModelFilterCombinations)
                    .HasForeignKey(d => d.DataModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataModel_DataModelId");
            });

            modelBuilder.Entity<ModelFilterCombinationalValue>(entity =>
            {
                entity.HasIndex(e => e.DimensionsId, "IX_ModelFilterCombinationalValues_DimensionsId");

                entity.HasIndex(e => e.DataModelFiltersId, "idx_datamodelfilters_datamodelfiltersid");

                entity.HasIndex(e => e.DimensionTypeId, "idx_dimensontype_dimesiontypeid");

                entity.HasIndex(e => e.ModelFilterCombinationsId, "idx_modelfiltercombination_modelfiltercombinationsid");

                entity.HasIndex(e => e.Id, "idx_modelfiltercombinationalvalues_id");

                entity.HasOne(d => d.DataModelFilters).WithMany(p => p.ModelFilterCombinationalValues)
                    .HasForeignKey(d => d.DataModelFiltersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataModelFIlters_DatamodelFiltersID");

                entity.HasOne(d => d.DimensionType).WithMany(p => p.ModelFilterCombinationalValues)
                    .HasForeignKey(d => d.DimensionTypeId)
                    .HasConstraintName("FK_DimensionType_DimensionTypeId");

                entity.HasOne(d => d.Dimensions).WithMany(p => p.ModelFilterCombinationalValues)
                    .HasForeignKey(d => d.DimensionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dimension_DimensionsId");

                entity.HasOne(d => d.ModelFilterCombinations).WithMany(p => p.ModelFilterCombinationalValues)
                    .HasForeignKey(d => d.ModelFilterCombinationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelFilterCombination_ModelFilterCombinationId");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasIndex(e => e.TenantId, "IX_Organizations_TenantId");

                entity.HasOne(d => d.Tenant).WithMany(p => p.Organizations).HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<OrganizationHeirarchy>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_OrganizationHeirarchies_OrganizationId").IsUnique();

                entity.HasOne(d => d.Organization).WithOne(p => p.OrganizationHeirarchy).HasForeignKey<OrganizationHeirarchy>(d => d.OrganizationId);
            });

            modelBuilder.Entity<OrganizationUser>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_OrganizationUsers_OrganizationId");

                entity.HasIndex(e => e.UserId, "IX_OrganizationUsers_UserId");

                entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationUsers).HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.User).WithMany(p => p.OrganizationUsers).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SampleModelFilterCombinationValue>(entity =>
            {
                entity.HasIndex(e => e.DimensionsId, "IX_SampleModelFilterCombinationValues_DimensionsId");

                entity.HasIndex(e => e.DataModelFiltersId, "fki_FK_DataModelFilters_DatamodelFiltersId");

                entity.HasIndex(e => e.ModelFilterCombinationsId, "fki_FK_ModelFlterCombinations_ModelFIlterCombinationsId");

                entity.HasIndex(e => e.Id, "idx_sampledatamodelfiltercombinationalvalue_sid");

                entity.HasOne(d => d.DataModelFilters).WithMany(p => p.SampleModelFilterCombinationValues)
                    .HasForeignKey(d => d.DataModelFiltersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataModelFilters_DatamodelFiltersId");

                entity.HasOne(d => d.Dimensions).WithMany(p => p.SampleModelFilterCombinationValues).HasForeignKey(d => d.DimensionsId);

                entity.HasOne(d => d.ModelFilterCombinations).WithMany(p => p.SampleModelFilterCombinationValues)
                    .HasForeignKey(d => d.ModelFilterCombinationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelFlterCombinations_ModelFIlterCombinationsId");
            });

            modelBuilder.Entity<Standard>(entity =>
            {
                entity.ToTable("Standard");

                entity.HasIndex(e => e.LanguageId, "IX_Standard_LanguageId");

                entity.HasIndex(e => e.TopicId, "IX_Standard_TopicId");

                entity.HasIndex(e => e.Id, "idx_standard_id");

                entity.HasOne(d => d.Language).WithMany(p => p.Standards).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Topic).WithMany(p => p.Standards).HasForeignKey(d => d.TopicId);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasIndex(e => e.Id, "idx_tenant_id");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.HasIndex(e => e.LanguageId, "IX_Topic_LanguageId");

                entity.HasIndex(e => e.Id, "idx_topic_id");

                entity.HasOne(d => d.Language).WithMany(p => p.Topics).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasIndex(e => e.LanguageId, "IX_UnitOfMeasures_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_UnitOfMeasures_OrganizationId");

                entity.HasIndex(e => e.UnitOfMeasureTypeId, "IX_UnitOfMeasures_UnitOfMeasureTypeId");

                entity.HasIndex(e => e.Id, "idx_unitofmeasure_id");

                entity.HasOne(d => d.Language).WithMany(p => p.UnitOfMeasures).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.UnitOfMeasures).HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.UnitOfMeasureType).WithMany(p => p.UnitOfMeasures).HasForeignKey(d => d.UnitOfMeasureTypeId);
            });

            modelBuilder.Entity<UnitOfMeasureTranslation>(entity =>
            {
                entity.HasKey(e => new { e.UnitOfMeasureId, e.LanguageId });

                entity.HasIndex(e => e.LanguageId, "IX_UnitOfMeasureTranslations_LanguageId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Language).WithMany(p => p.UnitOfMeasureTranslations).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.UnitOfMeasureTranslations).HasForeignKey(d => d.UnitOfMeasureId);
            });

            modelBuilder.Entity<UnitOfMeasureType>(entity =>
            {
                entity.HasIndex(e => e.LanguageId, "IX_UnitOfMeasureTypes_LanguageId");

                entity.HasIndex(e => e.OrganizationId, "IX_UnitOfMeasureTypes_OrganizationId");

                entity.HasIndex(e => e.Id, "idx_unitofmeasuretype_id");

                entity.HasOne(d => d.Language).WithMany(p => p.UnitOfMeasureTypes).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.Organization).WithMany(p => p.UnitOfMeasureTypes).HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<UnitOfMeasureTypeTranslation>(entity =>
            {
                entity.HasKey(e => new { e.UnitOfMeasureTypeId, e.LanguageId });

                entity.HasIndex(e => e.LanguageId, "IX_UnitOfMeasureTypeTranslations_LanguageId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Language).WithMany(p => p.UnitOfMeasureTypeTranslations).HasForeignKey(d => d.LanguageId);

                entity.HasOne(d => d.UnitOfMeasureType).WithMany(p => p.UnitOfMeasureTypeTranslations)
                    .HasForeignKey(d => d.UnitOfMeasureTypeId)
                    .HasConstraintName("FK_UnitOfMeasureTypeTranslations_UnitOfMeasureTypes_UnitOfMeas~");
            });

            modelBuilder.Entity<UploadedFile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("UploadedFile_pkey");

                entity.ToTable("UploadedFile");

                entity.HasIndex(e => e.DataModelValueId, "fki_FK_UploadFile_DefaultDataModelValues");

                entity.HasIndex(e => e.UserId, "fki_FK_UploadedFile_User_UserId");

                entity.Property(e => e.FileName).HasMaxLength(255);
                entity.Property(e => e.UploadDate).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.DataModelValue).WithMany(p => p.UploadedFiles)
                    .HasForeignKey(d => d.DataModelValueId)
                    .HasConstraintName("FK_UploadFile_DefaultDataModelValues");

                entity.HasOne(d => d.User).WithMany(p => p.UploadedFiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UploadedFile_User_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.LanguageId, "IX_Users_LanguageId");

                entity.HasIndex(e => e.Id, "idx_users_id");

                entity.HasOne(d => d.Language).WithMany(p => p.Users).HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

                entity.HasIndex(e => e.UserId, "IX_UserRoles_UserId").IsUnique();

                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User).WithOne(p => p.UserRole).HasForeignKey<UserRole>(d => d.UserId);
            });
            //modelBuilder.HasSequence("amendments_id_seq");
            //modelBuilder.HasSequence("UploadedFile_Id_seq");

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
