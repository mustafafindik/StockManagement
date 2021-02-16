using System.Collections.Generic;
using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string CategoryName { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
