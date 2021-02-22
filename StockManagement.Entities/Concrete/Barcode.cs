

using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class Barcode : BaseEntity, IEntity
    {
        public string BarcodeNumber { get; set; }

        public int ProductId { get; set; } //Fk
        public Product Product { get; set; }
    }
}
