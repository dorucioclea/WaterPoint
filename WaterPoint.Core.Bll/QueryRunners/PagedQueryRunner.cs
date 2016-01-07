using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners
{
    public class PagedQueryRunner<T, TOut> : IPagedQueryRunner<T, TOut>
        where T : IQueryParameter
        where TOut : IDataEntity, new()
    {
        private readonly IDapperDbContext _dapperDbContext;

        public PagedQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PagedPoco<IEnumerable<TOut>> Run(IQuery<T> query)
        {
            var rawResults = query.IsStoredProcedure
                    ? _dapperDbContext.ExecuteStoredProcedure<TOut, PagedPoco>(
                        query.Query,
                        PagedPoco.SplitOnColumn,
                        query.Parameters).ToArray()
                    : _dapperDbContext.List<TOut, PagedPoco>(
                        query.Query,
                        PagedPoco.SplitOnColumn,
                        query.Parameters).ToArray();

            return (!rawResults.Any())
                ? new PagedPoco<IEnumerable<TOut>>()
                {
                    TotalCount = 0,
                    Data = new List<TOut>()
                }
                : new PagedPoco<IEnumerable<TOut>>
                {
                    TotalCount = rawResults.First().Item2.TotalCount,
                    Data = rawResults.Select(i => i.Item1)
                };
        }
    }
}
