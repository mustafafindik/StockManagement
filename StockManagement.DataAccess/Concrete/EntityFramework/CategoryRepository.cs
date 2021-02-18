using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class CategoryRepository : EntityRepository<Category, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
