using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DataModelValuesConfiguration : IEntityTypeConfiguration<Domain.Entities.DataModelValues>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DataModelValues> builder)
        {
            builder.HasOne(mc => mc.Row)
                          .WithMany()
                          .HasForeignKey(mc => mc.RowId);

            builder.HasOne(mc => mc.Column)
                  .WithMany()
                  .HasForeignKey(mc => mc.ColumnId);
            builder.HasOne(mc => mc.Combination)
                  .WithMany()
                  .HasForeignKey(mc => mc.CombinationId);
        }
    }
}
