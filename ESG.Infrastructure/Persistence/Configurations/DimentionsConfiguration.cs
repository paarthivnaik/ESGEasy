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
    public class DimentionsConfiguration : IEntityTypeConfiguration<Dimentions>
    {
        public void Configure(EntityTypeBuilder<Dimentions> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });
            builder.HasMany(d => d.DataPointTypes)
                .WithOne(dpt => dpt.Dimentions)
                .HasForeignKey(dpt => dpt.DimentionId);
        }
    }
}
