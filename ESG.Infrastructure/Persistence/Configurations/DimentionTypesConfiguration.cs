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
    public class DimentionTypesConfiguration : IEntityTypeConfiguration<DimentionType>
    {
        public void Configure(EntityTypeBuilder<DimentionType> builder)
        {
            builder.HasKey(x => new { x.Id, x.OrganizationId });
        }
    }
}
