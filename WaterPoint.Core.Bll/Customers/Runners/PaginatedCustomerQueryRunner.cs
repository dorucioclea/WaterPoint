using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Runners
{
    public class PaginatedCustomerQueryRunner : DapperQueryRunner<PaginatedPoco<IEnumerable<BasicCustomerPoco>>>
    {
        public PaginatedCustomerQueryRunner(IDapperDbContext dapperDbContext)
            : base(dapperDbContext)
        {
        }

        public override PaginatedPoco<IEnumerable<BasicCustomerPoco>> Run(IQuery query)
        {
            var rawResults = Repository.List<BasicCustomerPoco, PaginatedPoco>(query.Query, "TotalCount", query.Parameters)
                .ToArray();

            if (!rawResults.Any())
                return null;

            var result = new PaginatedPoco<IEnumerable<BasicCustomerPoco>>
            {
                TotalCount = rawResults.First().Item2.TotalCount,
                Data = rawResults.Select(i => i.Item1)
            };

            return result;
        }
    }
}
