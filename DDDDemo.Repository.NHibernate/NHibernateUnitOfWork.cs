using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DDDDemo.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using ITransaction = DDDDemo.Repository.Interfaces.ITransaction;

namespace DDDDemo.Repository.NHibernate
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {

        public ISession Session { get; private set; }

        public NHibernateUnitOfWork(ISession session)
        {
            Session = session;
        }

        public void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
                Session = null;
            }
        }

        public void Flush()
        {
            Session.Flush();
        }

        public ITransaction BeginTransaction()
        {
            return new NHibernateTransaction(Session.BeginTransaction());
        }

        public void EndTransaction(ITransaction transaction)
        {
            if (transaction != null)
            {
                (transaction as IDisposable).Dispose();
                transaction = null;
            }
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Save(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Delete(entity);
        }

        public TEntity GetById<TEntity, TKey>(TKey id) where TEntity : class
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            return Session.Query<TEntity>().Where(expression).SingleOrDefault();
        }

        public IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Session.CreateCriteria<TEntity>().List<TEntity>();
        }
    }
}
