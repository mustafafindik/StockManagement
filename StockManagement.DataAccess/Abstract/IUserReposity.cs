using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.DataAccess;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.DataAccess.Abstract
{
    public interface IUserRepository: IEntityRepository<User>
    {
        List<Role> GetRoles(User user);
    }
}
