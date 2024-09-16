using ESG.Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class UnitOfMeasureTypeConfiguration : IEntityTypeConfiguration<UnitOfMeasureType>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasureType> builder)
        {
        }
    }
}
