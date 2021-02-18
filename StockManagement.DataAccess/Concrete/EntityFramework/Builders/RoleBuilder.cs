using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class RoleBuilder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
