using StockManagement.Core.Entities.Concrete;
using System.Collections.Generic;

namespace StockManagement.Business.Abstract
{
    /// <summary>
    /// Kullanıcı ile ilgili Verileri Çekmek İçin user iş Sınıfı inferface
    /// </summary>
    public interface IUserService
    {
        List<Role> GetRoles(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
