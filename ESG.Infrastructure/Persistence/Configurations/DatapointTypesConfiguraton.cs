using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DatapointTypesConfiguraton : IEntityTypeConfiguration<DataPointTypes>
    {
        public void Configure(EntityTypeBuilder<DataPointTypes> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });
            builder.HasOne(dpt => dpt.Dimentions)
                .WithMany(d => d.DataPointTypes)
                .HasForeignKey(dpt => dpt.DimentionId);

        }
    }
}
