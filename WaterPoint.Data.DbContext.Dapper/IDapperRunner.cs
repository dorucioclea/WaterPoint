using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IDapperRunner<T>
    {
        IDapperDbContext Repository { get; }
    }
}
