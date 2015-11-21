using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll
{
    public class UpdateCommandExecutor
    {
        private readonly IDapperDbContext _dapperDbContext;

        public UpdateCommandExecutor(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public bool Run(ICommand query)
        {
            var result = _dapperDbContext.NonQuery(query.Query, query.Parameters);

            return result > 0;
        }
    }
}
