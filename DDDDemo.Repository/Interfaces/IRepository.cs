using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDDDemo.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity GetById(TKey id);

        TEntity Get(Expression<Func<TEntity, bool>> where);

        IList<TEntity> GetAll();

        TSpecification Specify<TSpecification>() where TSpecification : class, ISpecicifcation<TEntity>;
    }
}