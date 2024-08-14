using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionTranslationsConfigurations : IEntityTypeConfiguration<DimensionTranslations>
    {
        public void Configure(EntityTypeBuilder<DimensionTranslations> builder)
        {
            builder.HasKey(x => new { x.DimensionsId, x.LanguageId });
            builder.HasOne(ut => ut.Language)
                .WithMany()
                .HasForeignKey(ut => ut.LanguageId);
            builder.HasOne(d => d.Dimensions)
                .WithMany(dpt => dpt.DimensionTranslations)
                .HasForeignKey(d => d.DimensionsId);
        }
    }
}
