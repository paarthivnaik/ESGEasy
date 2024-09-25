using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Entities.DataModels;
using System.Reflection.Emit;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class ModelFilterCombinationalValuesConfiguration : IEntityTypeConfiguration<ModelFilterCombinationalValues>
    {
        public void Configure(EntityTypeBuilder<ModelFilterCombinationalValues> builder)
        {
            builder.HasKey(mfcv => new { mfcv.DataModelFiltersId, mfcv.DimensionsId, mfcv.ModelFilterCombinationsId });
            builder.HasOne(mfcv => mfcv.DataModelFilters)
                .WithMany(a => a.ModelFilterCombinationalValues)
                .HasForeignKey(mfcv => mfcv.DataModelFiltersId);
            //builder.HasOne(mfcv => mfcv.ModelFilterCombinations) 
            //    .WithMany() 
            //    .HasForeignKey(mfcv => mfcv.ModelFilterCombinationsId);
            builder.HasMany(mfcv => mfcv.Dimensions) 
                .WithMany();

        }
    }
}
