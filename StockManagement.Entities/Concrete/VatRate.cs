using StockManagement.Core.Entities;

namespace StockManagement.Entities.Concrete
{
    public class VatRate : BaseEntity, IEntity
    {
        public string VatRateName { get; set; }
        public decimal VatRateValue { get; set; }



    }
}
