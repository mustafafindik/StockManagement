using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using StockManagement.Core.Entities;

namespace StockManagement.Core.DataAccess
{
    /// <summary>
    /// Burada Expression func lamda ile condition yazmamanıza olanak sağlar.
    /// nav ile Include edilecek sınıflar için kullanılur. İstediğimiz kadar gönderebilirz.
    /// </summary>
    /// <typeparam name="T"> Bu gönderilen Veritabanı Sınıfı Örnegin Product,Category..</typeparam>
    public interface IEntityRepository<T> where  T:class,IEntity,new()
    {
        T Get(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate, params string[] nav);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAll(params string[] nav);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params string[] nav);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
