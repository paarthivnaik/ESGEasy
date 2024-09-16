using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Entities.DomainEntities;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionTypesConfiguration : IEntityTypeConfiguration<DimensionType>
    {
        public void Configure(EntityTypeBuilder<DimensionType> builder)
        {
            builder.HasMany(d => d.Dimensions)
                .WithOne(dpt => dpt.DimensionType)
                .HasForeignKey(d => d.DimensionTypeId);
        }
    }
}
