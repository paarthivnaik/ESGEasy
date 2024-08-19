using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DatapointTypeTranslationConfiguration : IEntityTypeConfiguration<DatapointTypeTranslations>
    {
        public void Configure(EntityTypeBuilder<DatapointTypeTranslations> builder)
        {
            // Configure relationships
            builder.HasOne(dpt => dpt.DataPointTypes)
                .WithMany(d => d.DataPointTypeTranslations)
                .HasForeignKey(dpt => dpt.DatapointTypeId);

            // Additional configurations can be added here
            builder.HasOne(dpt => dpt.Language)
                .WithMany()
                .HasForeignKey(dpt => dpt.LanguageId);

            // Configuring table name and indexes (if needed)
            builder.ToTable("DatapointTypeTranslations");
            builder.HasIndex(dpt => new { dpt.DatapointTypeId, dpt.LanguageId }).IsUnique();
        }
    }
}
