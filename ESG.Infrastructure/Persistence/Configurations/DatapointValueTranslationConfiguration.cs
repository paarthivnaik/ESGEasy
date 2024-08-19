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
    public class DatapointValueTranslationConfiguration : IEntityTypeConfiguration<DatapointValueTranslations>
    {
        public void Configure(EntityTypeBuilder<DatapointValueTranslations> builder)
        {
            // Configure relationships
            builder.HasOne(dvt => dvt.DataPointValues)
                .WithMany()
                .HasForeignKey(dvt => dvt.DatapointValueId);

            builder.HasOne(dvt => dvt.Language)
                .WithMany()
                .HasForeignKey(dvt => dvt.LanguageId);

            // Configuring table name and indexes (if needed)
            builder.ToTable("DatapointValueTranslations");
            builder.HasIndex(dvt => new { dvt.DatapointValueId, dvt.LanguageId }).IsUnique();
        }
    }
}
