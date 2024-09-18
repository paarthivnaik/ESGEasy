using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESG.Domain.Entities.TenantAndUsers;
using System.Reflection.Emit;

namespace ESG.Infrastructure.Persistence.Configurations
{
    public class OrganizationUsersConfigurations : IEntityTypeConfiguration<OrganizationUser>
    {
        public void Configure(EntityTypeBuilder<OrganizationUser> builder)
        {
            builder.HasOne(ou => ou.User)
         .WithMany(u => u.OrganizationUsers)
         .HasForeignKey(ou => ou.UserId);

            //builder.HasOne(ou => ou.Organization)
            //    .WithMany(o => o.OrganizationUsers)
            //    .HasForeignKey(ou => ou.OrganizationId);
        }
    }
}
