using StockManagement.Core.Entities;
using System.Collections.Generic;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class City : BaseEntity, IEntity
    {
        public string CityName { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
