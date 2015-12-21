using System.Linq;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Executors
{
    public class CreateCommandExecutor<T> : ICommandExecutor<T>
        where T : IQueryParameter
    {
        private readonly IDapperDbContext _dapperDbContext;

        public CreateCommandExecutor(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public int Execute(ICommand<T> query)
        {
            var result = _dapperDbContext.List<int>(query.Query, query.Parameters).Single();

            return result;
        }
    }
}
