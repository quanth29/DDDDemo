using System;

namespace DDDDemo.Repository.Interfaces
{
    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork BeginUnitOfWork();

        void EndUnitOfWork(IUnitOfWork unitOfWork);
    }
}