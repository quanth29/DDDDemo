using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Repository.Interfaces;
using NHibernate;
using NHibernate.Cfg;

namespace DDDDemo.Repository.NHibernate
{
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        protected ISessionFactory SessionFactory { get; private set; }

        protected Configuration Configuration { get; private set; }

        public NHibernateUnitOfWorkFactory(string nhibernateConfigPath, Assembly assembly)
        {
            var cfg = new Configuration();

            cfg.Configure(nhibernateConfigPath);
            Configuration = cfg.AddAssembly(assembly);

            SessionFactory = Configuration.BuildSessionFactory();
        }


        public IUnitOfWork BeginUnitOfWork()
        {
            return new NHibernateUnitOfWork(SessionFactory.OpenSession());
        }

        public void EndUnitOfWork(IUnitOfWork unitOfWork)
        {
            var nhUnitOfWork = unitOfWork as NHibernateUnitOfWork;
            if (unitOfWork != null)
            {
                unitOfWork.Dispose();
                unitOfWork = null;
            }
        }

        public void Dispose()
        {
            if (SessionFactory != null)
            {
                (SessionFactory as IDisposable).Dispose();
                SessionFactory = null;
                Configuration = null;
            }
        }
    }
}
