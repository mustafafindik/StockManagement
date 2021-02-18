using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class SupplierRepository : EntityRepository<Supplier, ApplicationDbContext>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
