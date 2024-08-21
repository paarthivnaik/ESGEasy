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
    public class HierarchyConfiguration : IEntityTypeConfiguration<Hierarchy>
    {
        public void Configure(EntityTypeBuilder<Hierarchy> builder)
        {
            builder.Property(e => e.DimensionId)
                 .IsRequired(false);
            builder.Property(e => e.DataPointValuesId)
                .IsRequired(false);
        }
    }
}
