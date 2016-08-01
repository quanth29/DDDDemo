using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository.EntityFramework
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        
        public DbContext DbContext { get; protected set; }

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.SaveChanges();
                (DbContext as IDisposable).Dispose();
                DbContext = null;
            }
        }

        public void Flush()
        {
            DbContext.SaveChanges();
        }

        public ITransaction BeginTransaction()
        {
            return new EntityFrameworkTransaction(this);
        }

        public void EndTransaction(ITransaction transaction)
        {
            if(transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Attach(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public TEntity GetById<TEntity, TKey>(TKey id) where TEntity : class
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return DbContext.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>().ToList();
        }
    }
}
