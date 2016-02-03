using System.Linq;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public class QueryRunner: IQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public QueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public TOut Run<T, TOut>(IQuery<T, TOut> query) where TOut : IDataEntity where T : IQueryParameter
        {
            var result = query.IsStoredProcedure
                ? _dapperDbContext.ExecuteStoredProcedure<TOut>(query.Query, query.Parameters).SingleOrDefault()
                : _dapperDbContext.List<TOut>(query.Query, query.Parameters).SingleOrDefault();

            return result;
        }
    }
}
