using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Core.Entities.Concrete;

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
