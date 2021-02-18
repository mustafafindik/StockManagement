
using StockManagement.Core.DataAccess.EntityFrameworkCore;
using StockManagement.DataAccess.Abstract;
using StockManagement.DataAccess.Concrete.EntityFramework.Contexts;
using StockManagement.Entities.Concrete;

namespace StockManagement.DataAccess.Concrete.EntityFramework
{
    public class BarcodeRepository : EntityRepository<Barcode, ApplicationDbContext>, IBarcodeRepository
    {
        public BarcodeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
