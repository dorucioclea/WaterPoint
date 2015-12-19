using System.Linq;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Executors
{
    public class CreateCommandExecutor
    {
        private readonly IDapperDbContext _dapperDbContext;

        public CreateCommandExecutor(IDapperDbContext dapperDbContext)
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
