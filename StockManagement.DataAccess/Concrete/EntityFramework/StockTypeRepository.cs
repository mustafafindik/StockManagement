using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class StockTypeRepository : EntityRepository<StockType, ApplicationDbContext>, IStockTypeRepository
    {
        public StockTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
