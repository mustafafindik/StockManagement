using System.Collections.Generic;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class Warehouse : BaseEntity, IEntity
    {
        public string WarehouseName { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
