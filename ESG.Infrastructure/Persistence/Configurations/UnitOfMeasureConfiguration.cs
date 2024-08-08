using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });
            builder.HasOne(dpv => dpv.UnitOfMeasureTypes)
                .WithMany(dpt => dpt.UnitOfMeasure)
                .HasForeignKey(dpv => new { dpv.UnitOfMeasureTypeId, dpv.OrganizationId });
        }
    }
}
