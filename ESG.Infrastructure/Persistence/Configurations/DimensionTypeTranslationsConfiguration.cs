﻿using ESG.Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionTypeTranslationsConfiguration : IEntityTypeConfiguration<DimensionTypeTranslations>
    {
        public void Configure(EntityTypeBuilder<DimensionTypeTranslations> builder)
        {
            builder.HasKey(x => new { x.DimensionTypeId, x.LanguageId });
        }
    }
}
