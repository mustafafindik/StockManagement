using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Concrete;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Helpers
{
    public interface ISetDateAndUserService
    {
        IEntity ForAdd(BaseEntity entity);
        IEntity ForUpdate(BaseEntity entity);
    }
}
