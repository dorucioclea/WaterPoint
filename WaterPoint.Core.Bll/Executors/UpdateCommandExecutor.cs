using WaterPoint.Core.Domain;
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
            var result = _dapperDbContext.NonQuery(query.Query, query.Parameters);

            return result;
        }
    }
}
