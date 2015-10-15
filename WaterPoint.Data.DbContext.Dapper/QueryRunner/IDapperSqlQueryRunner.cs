using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Domain.QueryRunner
{
    public interface IDapperSqlQueryRunner<T> where T : class
    {
        IDapperDbContext Repository { get; }

        T Run(IQuery query);
    }
}
