using System.Linq;
using DDDDemo.Repository.Interfaces;
using NHibernate.Linq;

namespace DDDDemo.Repository.NHibernate
{
    public class NHibernateUnitOfWorkConvertor : IUnitOfWorkConvertor
    {
        public IQueryable<TEntity> ToQueryable<TEntity>(IUnitOfWork unitOfWork) where TEntity : class
        {
            return (unitOfWork as NHibernateUnitOfWork)?.Session.Query<TEntity>();
        }
    }
}
