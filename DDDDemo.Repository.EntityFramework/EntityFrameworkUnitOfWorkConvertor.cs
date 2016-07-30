using System.Linq;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository.EntityFramework
{
    public class EntityFrameworkUnitOfWorkConvertor : IUnitOfWorkConvertor
    {
        public IQueryable<TEntity> ToQueryable<TEntity>(IUnitOfWork unitOfWork) where TEntity : class
        {
            return (unitOfWork as EntityFrameworkUnitOfWork)?.DbContext.Set<TEntity>();
        }
    }
}
