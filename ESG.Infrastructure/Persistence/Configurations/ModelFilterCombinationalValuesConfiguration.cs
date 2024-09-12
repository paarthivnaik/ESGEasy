using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class ModelFilterCombinationalValuesConfiguration : IEntityTypeConfiguration<Domain.Entities.ModelFilterCombinationalValues>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ModelFilterCombinationalValues> builder)
        {
        }
    }
}
