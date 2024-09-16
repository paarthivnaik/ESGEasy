using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using ESG.Domain.Entities.DomainEntities;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionsConfiguration : IEntityTypeConfiguration<Dimensions>
    {
        public void Configure(EntityTypeBuilder<Dimensions> builder)
        {
            builder.HasOne(d => d.DimensionType)
                .WithMany(dpt => dpt.Dimensions)
                .HasForeignKey(d =>d.DimensionTypeId);
        }
    }
}
