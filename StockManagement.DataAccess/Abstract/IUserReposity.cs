using StockManagement.Core.DataAccess;
using StockManagement.Core.Entities.Concrete;
using System.Collections.Generic;

namespace StockManagement.DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
        List<Role> GetRoles(User user);
    }
}
