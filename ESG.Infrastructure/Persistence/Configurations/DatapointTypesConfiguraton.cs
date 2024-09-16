using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using ESG.Domain.Entities.DomainEntities;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DatapointTypesConfiguraton : IEntityTypeConfiguration<DataPointTypes>
    {
        public void Configure(EntityTypeBuilder<DataPointTypes> builder)
        {
            builder.HasMany(dpt => dpt.DataPointValues)
                .WithOne(d => d.DataPointType)
                .HasForeignKey(dpv => dpv.DatapointTypeId);

        }
    }
}
