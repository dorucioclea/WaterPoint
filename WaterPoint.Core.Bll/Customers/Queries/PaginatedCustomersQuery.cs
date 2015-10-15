using WaterPoint.Core.Bll.Enum;
using WaterPoint.Data.DbContext.Dapper;
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

        public void BuildQuery(int orgId)
        {
            var builder = _sqlBuilderFactory.Create<BasicCustomerPoco>(Crud.Read);

            builder
                .Analyze()
                .AddWhere<BasicCustomerPoco>(i => i.OrganizationId == orgId);

            var sql = builder.GetSql();

            Parameters = new { orgId };

            Query = sql;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }

    }
}
