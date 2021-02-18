using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class WarehouseRepository : EntityRepository<Warehouse, ApplicationDbContext>, IWarehouseRepository
    {
        public WarehouseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
