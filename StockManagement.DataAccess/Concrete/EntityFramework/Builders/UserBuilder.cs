using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework.Builders
{
    public class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

        }
    }


}
