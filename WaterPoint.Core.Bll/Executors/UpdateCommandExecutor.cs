using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Executors
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
