using Microsoft.EntityFrameworkCore;
using StockManagement.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StockManagement.Core.DataAccess.EntityFrameworkCore
{
    /// <summary>
    /// Bu Interface in Somut Sınıfıdır. 
    /// </summary>
    /// <typeparam name="T">Buradaki T Veritabanı Sınıflarından herangi birini alabilir.</typeparam>
    /// <typeparam name="TContext">Bu Veritabanı DbContext Sınıfından türeilmiş Sınıf</typeparam>
    public class EntityRepository<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where TContext : DbContext
    {
        private readonly TContext _context;

        public EntityRepository(TContext context)
        {
            _context = context;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {

            return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);

        }

        public T Get(Expression<Func<T, bool>> predicate, params string[] nav)
        {


            var query = _context.Set<T>();
            query = nav.Aggregate(query, (current, n) => (DbSet<T>)current.Include(n));
            return query.AsNoTracking().SingleOrDefault(predicate);

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {

            return predicate == null ? _context.Set<T>().AsNoTracking() : _context.Set<T>().Where(predicate).AsNoTracking();

        }

        public IQueryable<T> GetAll(params string[] nav)
        {

            var query = _context.Set<T>();
            query = nav.Aggregate(query, (current, n) => (DbSet<T>)current.Include(n));
            return query.AsNoTracking();

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params string[] nav)
        {

            var query = predicate == null ? _context.Set<T>() : _context.Set<T>().Where(predicate);
            query = nav.Aggregate(query, (current, n) => (DbSet<T>)current.Include(n));
            return query.AsNoTracking();

        }

        public void Add(T entity)
        {

            var addedEntityEntry = _context.Entry(entity);
            addedEntityEntry.State = EntityState.Added;
            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();

        }

        public void Update(T entity, int id)
        {
            var existingEntity = _context.Set<T>().Find(id);

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();


        }
    }
}
