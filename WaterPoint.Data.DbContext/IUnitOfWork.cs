using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.DbContext
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
