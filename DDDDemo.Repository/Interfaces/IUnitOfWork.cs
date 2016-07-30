using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDDDemo.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Flush();

        ITransaction BeginTransaction();

        void EndTransaction(ITransaction transaction);

        void Insert<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;

        TEntity GetById<TEntity, TKey>(TKey id) where TEntity : class;

        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;

        IList<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}