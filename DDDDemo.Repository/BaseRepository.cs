using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DDDDemo.Repository.Exceptions;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class 
    {

        protected ISpecificationLocator SpecificationLocator { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        public BaseRepository(ISpecificationLocator specificationLocator, IUnitOfWork unitOfWork)
        {
            EnsureNotNull(specificationLocator);
            EnsureNotNull(unitOfWork);

            SpecificationLocator = specificationLocator;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
		/// Checks if given instance is not null. Use the method to validate input parameters.
		/// </summary>
		protected void EnsureNotNull(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException("o", "Argument can not be null.");
            }
        }

#region Implement Repository

        public virtual void Insert(TEntity entity)
        {
            UnitOfWork.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            UnitOfWork.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            UnitOfWork.Delete(entity);
        }

        public virtual TEntity GetById(TKey id)
        {
            return UnitOfWork.GetById<TEntity, TKey>(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return UnitOfWork.Get(where);
        }


        public virtual IList<TEntity> GetAll()
        {
            return UnitOfWork.GetAll<TEntity>();
        }

        public TSpecification Specify<TSpecification>() where TSpecification : class, ISpecicifcation<TEntity>
        {
            var specification = default(TSpecification);
            try
            {
                specification = SpecificationLocator.Resolve<TSpecification, TEntity>();
            }
            catch (Exception ex)
            {
                throw new GenericRepositoryException(
                    $"Could not resolve requested specification {typeof(TSpecification).FullName} for entity {typeof(TEntity).FullName} from the specification locator."
                    , ex
                    );
            }

            specification.Initialize(UnitOfWork);
            return specification;
        }
#endregion
    }
}
