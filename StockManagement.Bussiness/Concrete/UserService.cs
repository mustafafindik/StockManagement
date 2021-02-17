using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Business.Abstract;
using StockManagement.Core.Entities.Concrete;
using StockManagement.DataAccess.Abstract;

namespace StockManagement.Business.Concrete
{
    /// <summary>
    /// Kullanıcı ile ilgili Verileri Çekmek İçin user iş Sınıfı
    /// </summary>
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Role> GetRoles(User user)
        {
            return _userRepository.GetRoles(user);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(q => q.Email == email);
        }
    }
}
