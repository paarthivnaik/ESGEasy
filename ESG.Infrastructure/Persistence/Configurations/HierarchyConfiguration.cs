using ESG.Domain.Entities;
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
    public class HierarchyConfiguration : IEntityTypeConfiguration<Hierarchy>
    {
        public void Configure(EntityTypeBuilder<Hierarchy> builder)
        {
           // builder
           //.HasOne(h => h.DimensionType) // Ensure this matches the property name
           //.WithMany() // Assuming DimensionType does not have a collection of Hierarchies
           //.HasForeignKey(h => h.NodeId);
           // builder
           //.HasOne(h => h.Dimension) // Ensure this matches the property name
           //.WithMany() // Assuming Dimension does not have a collection of Hierarchies
           //.HasForeignKey(h => h.NodeId);
        }
    }
}
