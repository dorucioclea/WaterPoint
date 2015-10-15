using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.QueryRunner;

namespace WaterPoint.Data.DbContext.Dapper
{
    public abstract class DapperQueryRunner<T> : IDapperSqlQueryRunner<T>
        where T : class
    {
        protected DapperQueryRunner(IDapperDbContext dapperDbContext)
        {
            Repository = dapperDbContext;
        }
        public IDapperDbContext Repository { get; private set; }

        public abstract T Run(IQuery query);
    }
}
