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
    public class DimensionsConfiguration : IEntityTypeConfiguration<Dimensions>
    {
        public void Configure(EntityTypeBuilder<Dimensions> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });
            builder.HasOne(d => d.DimensionType)
                .WithMany(dpt => dpt.Dimensions)
                .HasForeignKey(dpv => new { dpv.DimentionTypeId, dpv.OrganizationId });
        }
    }
}
