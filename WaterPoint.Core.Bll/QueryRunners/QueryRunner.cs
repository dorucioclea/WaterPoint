using System.Linq;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public class QueryRunner<T, TOut> : IQueryRunner<T, TOut> where TOut : IDataEntity where T : IQueryParameter
    {
        private readonly IDapperDbContext _dapperDbContext;

        public QueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public TOut Run(IQuery<T> query)
        {
            var result = _dapperDbContext
                   .List<TOut>(query.Query, query.Parameters)
                   .SingleOrDefault();

            return result;
        }
    }
}
