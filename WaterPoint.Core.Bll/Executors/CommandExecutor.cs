using System.Linq;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Executors
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IDapperDbContext _dapperDbContext;

        public CommandExecutor(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public int Execute<T>(ICommand<T> query) where T : IQueryParameter
        {
            var result = query.IsStoredProcedure
                ? _dapperDbContext.ExecuteStoredProcedure<int>(query.Query, query.Parameters).Single()
                : _dapperDbContext.List<int>(query.Query, query.Parameters).Single();

            return result;
        }

        public int ExecuteNonQuery<T>(ICommand<T> query) where T : IQueryParameter
        {
            var result = (query.IsStoredProcedure)
                ? _dapperDbContext.ExecuteStoredProcedure<int>(query.Query, query.Parameters).Single()
                : _dapperDbContext.NonQuery(query.Query, query.Parameters);

            return result;
        }
    }
}
