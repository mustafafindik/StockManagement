using StockManagement.Core.DataAccess;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}
