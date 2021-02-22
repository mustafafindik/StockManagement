
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Concrete;

namespace StockManagement.Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public string CustomerName { get; set; }
        public string TaxId { get; set; }
        public string TaxOffice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
