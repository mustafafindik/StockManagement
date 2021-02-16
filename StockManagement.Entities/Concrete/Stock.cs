
using System;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class Stock : BaseEntity, IEntity
    {
        public int StockTypeId { get; set; }
        public StockType StockType { get; set; }

        public decimal Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public DateTime AddDate { get; set; }
    }
}
