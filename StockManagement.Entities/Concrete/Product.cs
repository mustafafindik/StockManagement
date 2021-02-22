

using StockManagement.Core.Entities;
using System.Collections.Generic;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Desc { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public int UnitId { get; set; } //FK
        public Unit Unit { get; set; }

        public int SalesVatRateId { get; set; } //Fk
        public VatRate SalesVatRate { get; set; }

        public int PurchaseVatRateId { get; set; } //Fk
        public VatRate PurchaseVatRate { get; set; }


        public decimal Sim { get; set; }

        public int WarehouseId { get; set; } //Fk
        public Warehouse Warehouse { get; set; }

        public int SubCategoryId { get; set; } //Fk
        public SubCategory SubCategory { get; set; }


        public virtual ICollection<Barcode> Barcodes { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
