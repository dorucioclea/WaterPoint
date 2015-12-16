using System;
using System.Collections.Generic;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.QueryRunners.Customers
{
    public class ListPaginatedCustomersStoredProcQueryRunner : IPaginatedEntitiesRunner<Customer>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListPaginatedCustomersStoredProcQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public PaginatedPoco<IEnumerable<Customer>> Run(IQuery query)
        {
            throw new NotImplementedException();
            //var rawResults = _dapperDbContext
            //    .ExecuteStoredProcedure<Customer, PaginatedPoco>(
            //        query.Query,
            //        PaginatedPoco.SplitOnColumn,
            //        query.Parameters)
            //    .ToArray();

            //if (!rawResults.Any())
            //    return null;

            //var result = new PaginatedPoco<IEnumerable<Customer>>
            //{
            //    TotalCount = rawResults.First().Item2.TotalCount,
            //    Data = rawResults.Select(i => i.Item1)
            //};

            //return result;
        }
    }
}
