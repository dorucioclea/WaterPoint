using System;

namespace WaterPoint.Core.Domain.Db
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Begin();
        void Commit();
        void Rollback();
    }
}
