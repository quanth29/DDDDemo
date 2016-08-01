using DDDDemo.Repository.Interfaces;
using INHibernateTransaction = NHibernate.ITransaction;

namespace DDDDemo.Repository.NHibernate
{
    public class NHibernateTransaction : ITransaction
    {
        protected INHibernateTransaction Transaction { get; private set; }

        public NHibernateTransaction(INHibernateTransaction transaction)
        {
            Transaction = transaction;
        }

        public void Dispose()
        {
            if (Transaction == null) return;
            Transaction.Dispose();
            Transaction = null;
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }
    }
}
