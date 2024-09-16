using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Entities.DomainEntities;

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

            builder.HasIndex(dvt => new { dvt.DatapointValueId, dvt.LanguageId }).IsUnique();
        }
    }
}
