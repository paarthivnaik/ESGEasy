using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Entities.DataModels;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DataModelValuesConfiguration : IEntityTypeConfiguration<DataModelValues>
    {
        public void Configure(EntityTypeBuilder<DataModelValue> builder)
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
            builder.HasOne(mc => mc.ResponsibleUser)
                  .WithMany()
                  .HasForeignKey(mc => mc.ResponsibleUserId);
            builder.HasOne(mc => mc.AccountableUser)
                  .WithMany()
                  .HasForeignKey(mc => mc.AccountableUserId);
        }
    }
}
