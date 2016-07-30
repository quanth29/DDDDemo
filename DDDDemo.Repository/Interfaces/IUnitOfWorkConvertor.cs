using System.Linq;

namespace DDDDemo.Repository.Interfaces
{
    public interface IUnitOfWorkConvertor
    {
        IQueryable<TEntity> ToQueryable<TEntity>(IUnitOfWork unitOfWork) where TEntity : class;
    }
}