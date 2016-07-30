using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDDDemo.Repository.Interfaces
{
    public interface ISpecicifcationResult<TEntity> where TEntity : class
    {
        ISpecicifcationResult<TEntity> Take(int count);

        ISpecicifcationResult<TEntity> Skip(int count);

        ISpecicifcationResult<TEntity> OrderByAscending<TKey>(Expression<Func<TEntity, TKey>> keyExpression);

        ISpecicifcationResult<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> kExpression);

        IList<TEntity> ToList();

        TEntity Single();

        TEntity SingleOrDefault();
    }
}