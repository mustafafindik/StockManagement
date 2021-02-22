using StockManagement.Core.Entities;
using System.Collections.Generic;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class SubCategory : BaseEntity, IEntity
    {
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; } //Fk
        public Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
