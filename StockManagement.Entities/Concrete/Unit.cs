using StockManagement.Core.Entities;
using System.Collections.Generic;

namespace StockManagement.Entities.Concrete
{
    public class Unit : BaseEntity, IEntity
    {
        public string UnitName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
