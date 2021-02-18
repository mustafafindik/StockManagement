using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class UnitRepository : EntityRepository<Unit, ApplicationDbContext>, IUnitRepository
    {
        public UnitRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
