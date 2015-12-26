using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public class PaginatedQueryRunner<T, TOut> : IListEntitiesRunner<T, TOut> where T : IQueryParameter
    {
        private readonly IDapperDbContext _dapperDbContext;

        public PaginatedQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<TOut>> Run(IQuery<T> query)
        {
            var rawResults = _dapperDbContext
                .List<TOut, PaginatedPoco>(
                    query.Query,
                    PaginatedPoco.SplitOnColumn,
                    query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<TOut>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
