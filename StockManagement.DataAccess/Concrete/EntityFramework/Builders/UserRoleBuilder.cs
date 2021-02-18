using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    /// <summary>
    /// Burada User ve Role Arasında Çoka Çok ilişki olduğu için Ara Sınıf kullanıldı. 
    /// </summary>
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
