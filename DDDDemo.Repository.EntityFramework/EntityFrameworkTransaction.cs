using System;
using System.Transactions;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Repository.EntityFramework
{
    public class EntityFrameworkTransaction : ITransaction
    {

        protected EntityFrameworkUnitOfWork UnitOfWork { get; private set; }

        protected TransactionScope TransactionScope { get; private set; }

        public EntityFrameworkTransaction(EntityFrameworkUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            TransactionScope = new TransactionScope();
        }

        public void Commit()
        {
            UnitOfWork.Flush();
            TransactionScope.Complete();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (TransactionScope != null)
            {
               (TransactionScope as IDisposable).Dispose();
                TransactionScope = null;
                UnitOfWork = null;
            }
        }
    }
}
