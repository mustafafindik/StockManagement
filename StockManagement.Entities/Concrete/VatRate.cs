using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class VatRate : BaseEntity, IEntity
    {
        public string VatRateName { get; set; }
        public decimal VatRateValue { get; set; }



    }
}
