using ESG.Domain.Entities.TenantAndUsers;
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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(u => u.User) // A User has one UserRole
        .WithOne(ur => ur.Role) // A UserRole belongs to one User
         .HasForeignKey<UserRole>(ur => ur.UserId);

            builder.HasOne(u => u.Role) // A User has one UserRole
        .WithMany(ur => ur.UserRole) // A UserRole belongs to one User
        .HasForeignKey(ur => ur.RoleId);
        }
    }
}
