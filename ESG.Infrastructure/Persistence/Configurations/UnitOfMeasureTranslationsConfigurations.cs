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
            builder.HasKey(x => new { x.Id});
            builder.HasOne(dpv => dpv.UnitOfMeasure)
                .WithMany(dpt => dpt.UnitOfMeasureTranslations)
                .HasForeignKey(pv => new { pv.UnitOfMeasureId, pv.LanguageId });
        }
    }
}
