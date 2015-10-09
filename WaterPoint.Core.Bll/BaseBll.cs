using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll
{
    public abstract class BaseBll
    {
        /// <summary>
        /// Use to perform simple CRUD action. For complex queries, use Nhibernate or stored proc
        /// </summary>
        public ISqlBuilderFactory SqlBuilderFactory { get; private set; }

        public IDapperDbContext Repository { get; private set; }

        protected BaseBll(IDapperDbContext dapperDbContext, ISqlBuilderFactory sqlBuilderFactory)
        {
            SqlBuilderFactory = sqlBuilderFactory;
            Repository = dapperDbContext;
        }
    }
}
