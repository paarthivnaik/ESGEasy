﻿using ESG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DatapointValuesConfiguration : IEntityTypeConfiguration<DataPointValues>
    {
        public void Configure(EntityTypeBuilder<DataPointValues> builder)
        {
            builder.HasOne(dpv => dpv.DataPointType)
                .WithMany(dpt => dpt.DataPointValues)
                .HasForeignKey(dpv => dpv.DatapointTypeId);
        }
    }
}
