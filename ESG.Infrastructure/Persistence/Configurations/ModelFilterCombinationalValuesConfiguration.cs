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
    public class ModelFilterCombinationalValuesConfiguration : IEntityTypeConfiguration<ModelFilterCombinationalValues>
    {
        public void Configure(EntityTypeBuilder<ModelFilterCombinationalValues> builder)
        {
        }
    }
}
