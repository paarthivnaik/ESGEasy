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
    public class DataModelConfigurationsConfiguration : IEntityTypeConfiguration<ModelConfiguration>
    {
        public void Configure(EntityTypeBuilder<ModelConfiguration> builder)
        {
            builder.HasOne(mc => mc.Row)
                          .WithMany() 
                          .HasForeignKey(mc => mc.RowId); 

            builder.HasOne(mc => mc.Column)
                  .WithMany() 
                  .HasForeignKey(mc => mc.ColumnId);
        }
    }
}
