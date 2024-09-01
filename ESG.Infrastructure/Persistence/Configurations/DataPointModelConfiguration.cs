using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DataPointModelConfiguration : IEntityTypeConfiguration<Domain.Entities.DataModel>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DataModel> builder)
        {

            //builder.HasOne(dpv => dpv.DataPointTypes)
            //    .WithMany(dpt => dpt.DatapointModels)
            //    .HasForeignKey(dpv => dpv.DatapointId);

            //builder.HasOne(dpv => dpv.Dimentions)
            //    .WithMany(dpt => dpt.DatapointModels)
            //    .HasForeignKey(dpv => dpv.DimentionsId);
        }
    }
}
