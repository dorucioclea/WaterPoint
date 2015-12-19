using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class GetCustomerByIdQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetCustomerByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int customerId)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<Customer>();
            builder.AddConditions<Customer>(i => i.OrganizationId == orgId && i.Id == customerId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                customerId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
