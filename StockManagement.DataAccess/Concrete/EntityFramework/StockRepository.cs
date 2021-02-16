using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class StockRepository : EntityRepository<Stock,ApplicationDbContext>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
