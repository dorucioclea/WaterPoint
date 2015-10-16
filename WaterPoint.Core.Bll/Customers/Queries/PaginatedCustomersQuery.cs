using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Queries
{
    public class PaginatedCustomersQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public PaginatedCustomersQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int offset, int pageSize)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder<BasicCustomerPoco>>();

            builder.Analyze();
            builder.AddWhere<BasicCustomerPoco>(i => i.OrganizationId == orgId);
            builder.AddOrderBy<BasicCustomerPoco>(i => new { i.Id }, false);
            builder.AddOffset(offset, pageSize);

            var sql = builder.GetSql();

            Parameters = new { orgId };

            Query = sql;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }

    }
}
