﻿using StockManagement.Core.Entities;
using System.Collections.Generic;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class StockType : BaseEntity, IEntity
    {
        public string StockTypeName { get; set; }
        public int Factor { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
