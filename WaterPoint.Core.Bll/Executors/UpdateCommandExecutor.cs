using System.Linq;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Executors
{
    public class UpdateCommandExecutor<T> :
        ICommandExecutor<T> where T : IQueryParameter
    {
        private readonly IDapperDbContext _dapperDbContext;

        public UpdateCommandExecutor(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public int Execute(ICommand<T> query)
        {
            var result = (query.IsStoredProcedure)
                ? _dapperDbContext.ExecuteStoredProcedure<int>(query.Query, query.Parameters).Single()
                : _dapperDbContext.NonQuery(query.Query, query.Parameters);

            return result;
        }
    }
}
