﻿using StockManagement.Core.Entities;
using StockManagement.Entities.Concrete;

namespace StockManagement.Business.Helpers
{
    public interface ISetDateAndUserService
    {
        IEntity ForAdd(BaseEntity entity);
        IEntity ForUpdate(BaseEntity entity);
    }
}
