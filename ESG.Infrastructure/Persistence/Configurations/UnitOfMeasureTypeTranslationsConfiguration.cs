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
    public class UnitOfMeasureTypeTranslationsConfiguration : IEntityTypeConfiguration<UnitOfMeasureTypeTranslations>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasureTypeTranslations> builder)
        {
            builder.HasKey(x => new { x.UnitOfMeasureTypeId, x.LanguageId });

            builder.HasOne(ut => ut.UnitOfMeasureType)
                .WithMany(u => u.UnitOfMeasureTypeTranslations)
                .HasForeignKey(ut => ut.UnitOfMeasureTypeId);

        }
    }
}
