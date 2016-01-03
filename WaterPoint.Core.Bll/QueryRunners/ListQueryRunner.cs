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
    public class ListQueryRunner<T, TOut> : IListQueryRunner<T, TOut>
        where T : IQueryParameter
        where TOut : new()
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<TOut>> Run(IQuery<T> query)
        {
            var rawResults = query.IsStoredProcedure
                    ? _dapperDbContext.ExecuteStoredProcedure<TOut, PaginatedPoco>(
                        query.Query,
                        PaginatedPoco.SplitOnColumn,
                        query.Parameters).ToArray()
                    : _dapperDbContext.List<TOut, PaginatedPoco>(
                        query.Query,
                        PaginatedPoco.SplitOnColumn,
                        query.Parameters).ToArray();

            return (!rawResults.Any())
                ? new PaginatedPoco<IEnumerable<TOut>>()
                {
                    TotalCount = 0,
                    Data = new List<TOut>()
                }
                : new PaginatedPoco<IEnumerable<TOut>>
                {
                    TotalCount = rawResults.First().Item2.TotalCount,
                    Data = rawResults.Select(i => i.Item1)
                };
        }
    }
}
