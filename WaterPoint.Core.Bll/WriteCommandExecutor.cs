using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll
{
    public class WriteCommandExecutor
    {
        private readonly IDapperDbContext _dapperDbContext;

        public WriteCommandExecutor(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public int Run(ICommand query)
        {
            var result = _dapperDbContext.List<int>(query.Query, query.Parameters).Single();

            return result;
        }
    }
}
