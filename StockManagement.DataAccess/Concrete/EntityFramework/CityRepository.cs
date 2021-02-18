using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class CityRepository : EntityRepository<City, ApplicationDbContext>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
