﻿using StockManagement.Core.DataAccess;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Abstract
{
    public interface ISupplierRepository : IEntityRepository<Supplier>
    {
    }
}
