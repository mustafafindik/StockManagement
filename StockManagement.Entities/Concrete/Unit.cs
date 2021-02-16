using System.Collections.Generic;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class Unit : BaseEntity, IEntity
    {
        public string UnitName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
