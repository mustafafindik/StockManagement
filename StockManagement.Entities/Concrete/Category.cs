using StockManagement.Core.Entities;
using System.Collections.Generic;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
