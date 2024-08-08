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
    public class DataPointModelConfiguration : IEntityTypeConfiguration<DatapointModel>
    {
        public void Configure(EntityTypeBuilder<DatapointModel> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });

            builder.HasOne(dpv => dpv.DataPointTypes)
                .WithMany(dpt => dpt.DatapointModels)
                .HasForeignKey(dpv => new { dpv.DatapointId, dpv.OrganizationId });

            builder.HasOne(dpv => dpv.Dimentions)
                .WithMany(dpt => dpt.DatapointModels)
                .HasForeignKey(dpv => new { dpv.DimentionsId, dpv.OrganizationId });
        }
    }
}
