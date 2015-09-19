using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Core.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Begin();
        void Commit();
        void Rollback();
    }
}
