using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository.QueryableSpecification
{
    public class QueryableSpecificationResult<TEntity> : ISpecicifcationResult<TEntity> where TEntity : class 
    {

        protected IQueryable<TEntity> Queryable { get; set; }

        public QueryableSpecificationResult(IQueryable<TEntity> queryable)
        {
            Queryable = queryable;
        }

        public ISpecicifcationResult<TEntity> Take(int count)
        {
            Queryable = Queryable.Take(count);
            return this;
        }

        public ISpecicifcationResult<TEntity> Skip(int count)
        {
            Queryable = Queryable.Skip(count);
            return this;
        }

        public ISpecicifcationResult<TEntity> OrderByAscending<TKey>(Expression<Func<TEntity, TKey>> keyExpression)
        {
            Queryable = Queryable.OrderBy(keyExpression);
            return this;
        }

        public ISpecicifcationResult<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> keyEpression)
        {
            Queryable = Queryable.OrderByDescending(keyEpression);
            return this;
        }

        public IList<TEntity> ToList()
        {
            return Queryable.ToList();
        }

        public TEntity Single()
        {
            return Queryable.Single();
        }

        public TEntity SingleOrDefault()
        {
            return Queryable.SingleOrDefault();
        }
    }

    public abstract class QueryableSpecification<TEntity> : ISpecicifcation<TEntity> where TEntity : class
    {
        protected IQueryable<TEntity> Queryable { get; set; }

        protected IUnitOfWorkConvertor UnitOfWorkConvertor { get; private set; }

        protected QueryableSpecification( IUnitOfWorkConvertor unitOfWorkConvertor)
        {
            if (unitOfWorkConvertor == null)
            {
                throw new ArgumentNullException("unitOfWorkConvertor");
            }

            UnitOfWorkConvertor = unitOfWorkConvertor;
        }

        public virtual void Initialize(IUnitOfWork unitOfWork)
        {
            Queryable = UnitOfWorkConvertor.ToQueryable<TEntity>(unitOfWork);
        }

        public ISpecicifcationResult<TEntity> ToResult()
        {
            return new QueryableSpecificationResult<TEntity>(Queryable);
        }
    }
}
