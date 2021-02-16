using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class VatRateRepository : EntityRepository<VatRate,ApplicationDbContext>, IVatRateRepository
    {
        public VatRateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
