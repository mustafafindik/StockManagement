using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class UserRoleBuilder : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(c => c.UserRoles).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Role).WithMany(c => c.UserRoles).HasForeignKey(p => p.RoleId);
        }
    }
}
