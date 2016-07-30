using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository.EntityFramework
{
    public class EntityFrameworkUnitOfWorkFactory : IUnitOfWorkFactory
    {

        protected string ConnectionString { get; private set; }

        protected DbModel DbModel { get; private set; }

        public IUnitOfWork BeginUnitOfWork()
        {
            return new EntityFrameworkUnitOfWork(CreatedDbContext());
        }

        private DbContext CreatedDbContext()
        {
            return new DbContext(ConnectionString, DbModel.Compile());
        }

        public void EndUnitOfWork(IUnitOfWork unitOfWork)
        {
            var efUnitOfWork = unitOfWork as EntityFrameworkUnitOfWork;
            if (efUnitOfWork != null)
            {
                efUnitOfWork.Dispose();
                efUnitOfWork = null;
            }
        }

        public void Dispose()
        {
            ConnectionString = null;
            DbModel = null;
        }
    }
}
