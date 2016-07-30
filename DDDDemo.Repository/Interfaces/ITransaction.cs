using System;

namespace DDDDemo.Repository.Interfaces
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}