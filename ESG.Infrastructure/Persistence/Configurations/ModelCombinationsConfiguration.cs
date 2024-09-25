using ESG.Domain.Entities.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class ModelCombinationsConfiguration : IEntityTypeConfiguration<ModelCombinations>
    {
        public void Configure(EntityTypeBuilder<ModelCombinations> builder)
        {

        }
    }
}
