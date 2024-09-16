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
    public class DatapointValuesConfiguration : IEntityTypeConfiguration<DataPointValues>
    {
        public void Configure(EntityTypeBuilder<DataPointValues> builder)
        {
            builder.HasOne(dpv => dpv.DataPointType)
                .WithMany(dpt => dpt.DataPointValues)
                .HasForeignKey(dpv => dpv.DatapointTypeId);
            builder.HasOne(dp => dp.Organization)
            .WithMany(a => a.DataPointValues)
            .HasForeignKey(dp => dp.OrganizationId);
            builder.HasMany(dp => dp.DatapointTypeTranslations)
            .WithOne()
            .HasForeignKey(dpt => dpt.DatapointTypeId);

            builder.HasOne(dp => dp.Currency)
            .WithMany()
            .HasForeignKey(dp => dp.CurrencyId)
            .IsRequired(false);
        }
    }
}
