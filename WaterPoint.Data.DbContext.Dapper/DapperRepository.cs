using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.Data.DbContext.Dapper
{
    public abstract class DapperRepository
    {
        protected DapperRepository(IDapperDbContext dapperDbContext)
        {
            Repository = dapperDbContext;
        }

        public IDapperDbContext Repository { get; private set; }
    }
}
