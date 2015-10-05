using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll
{
    public abstract class BaseBll
    {
        public IDapperDbContext Repository { get; }

        protected BaseBll(IDapperUnitOfWork dapperUnitOfWork)
        {
            Repository = dapperUnitOfWork.DbContext;
        }
    }
}
