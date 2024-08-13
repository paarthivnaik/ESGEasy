using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionsConfiguration : IEntityTypeConfiguration<ESG.Domain.Entities.Dimensions>
    {
        public void Configure(EntityTypeBuilder<ESG.Domain.Entities.Dimensions> builder)
        {
            builder.HasOne(d => d.DimensionType)
                .WithMany(dpt => dpt.Dimensions)
                .HasForeignKey(d =>d.DimensionTypeId);
            builder.HasMany(d => d.DimensionTranslations)
                .WithOne(dpt => dpt.Dimensions)
                .HasForeignKey(d => d.DimensionsId);
        }
    }
}
