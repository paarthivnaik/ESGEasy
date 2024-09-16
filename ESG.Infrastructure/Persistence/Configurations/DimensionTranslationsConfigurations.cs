using ESG.Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class DimensionTranslationsConfigurations : IEntityTypeConfiguration<DimensionTranslations>
    {
        public void Configure(EntityTypeBuilder<DimensionTranslations> builder)
        {
            builder.HasKey(x => new { x.DimensionsId, x.LanguageId });
        }
    }
}
