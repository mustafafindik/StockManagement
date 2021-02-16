using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StockManagement.Core.Entities;

namespace StockManagement.Core.DataAccess.EntityFrameworkCore
{
    /// <summary>
    /// Bu Interface in Somut Sınıfıdır. 
    /// </summary>
    /// <typeparam name="T">Buradaki T Veritabanı Sınıflarından herangi birini alabilir.</typeparam>
    /// <typeparam name="TContext">Bu Veritabanı DbContext Sınıfından türeilmiş Sınıf</typeparam>
    public class EntityRepository<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where  TContext: DbContext,  new()
    {
        public T Get(Expression<Func<T, bool>> predicate)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(predicate);
            }
        }

        public T Get(Expression<Func<T, bool>> predicate, params string[] nav)
        {
             
            using (var context = new TContext())
            {
                var query = context.Set<T>();
                query = nav.Aggregate(query, (current, n) => (DbSet<T>) current.Include(n));
                return query.SingleOrDefault(predicate);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            using (var context = new TContext())
            {
                return predicate == null ? context.Set<T>() : context.Set<T>().Where(predicate);
            }
        }

        public IQueryable<T> GetAll(params string[] nav)
        {
            using (var context = new TContext())
            {
                var query = context.Set<T>();
                query = nav.Aggregate(query, (current, n) => (DbSet<T>)current.Include(n));
                return query;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params string[] nav)
        {
            using (var context = new TContext())
            {
                var query =  predicate == null ? context.Set<T>() : context.Set<T>().Where(predicate);
                query = nav.Aggregate(query, (current, n) => (DbSet<T>)current.Include(n));
                return query;
            }
        }

        public void Add(T entity)
        {
            using (var context = new TContext())
            {
                var addedEntityEntry = context.Entry(entity);
                addedEntityEntry.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                var deletedEntityEntry = context.Entry(entity);
                deletedEntityEntry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                var modifiedEntityEntry = context.Entry(entity);
                modifiedEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
