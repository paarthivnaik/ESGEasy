using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class UnitOfMeasureTranslationsConfigurations : IEntityTypeConfiguration<UnitOfMeasureTranslations>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasureTranslations> builder)
        {
            // Configure composite primary key
            builder.HasKey(x => new { x.UnitOfMeasureId, x.LanguageId });

            // Configure relationship with UnitOfMeasure
            builder.HasOne(ut => ut.UnitOfMeasure)
                .WithMany(u => u.UnitOfMeasureTranslations)
                .HasForeignKey(ut => ut.UnitOfMeasureId);

        }
    }
}
