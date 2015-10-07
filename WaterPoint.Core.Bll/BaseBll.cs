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
        /// Use to perform simple CRUD action.
        /// </summary>
        public ISqlBuilderFactory SqlBuilderFactory { get; }

        public IDapperDbContext Repository { get; }

        protected BaseBll(IDapperDbContext dapperDbContext, ISqlBuilderFactory sqlBuilderFactory)
        {
            SqlBuilderFactory = sqlBuilderFactory;
            Repository = dapperDbContext;
        }
    }
}
