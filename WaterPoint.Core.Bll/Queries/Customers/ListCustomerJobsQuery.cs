using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class ListCustomerJobsQuery : IQuery<ListCustomerJobs>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
            SELECT
                {SqlPatterns.Columns}
                ,[TotalCount]
            FROM
                {SqlPatterns.FromTable}
                {SqlPatterns.Join}
                CROSS APPLY(
                    SELECT COUNT(*) TotalCount
                    FROM
                        {SqlPatterns.FromTable}
                        {SqlPatterns.Join}
                    WHERE
                        {SqlPatterns.Where}
                )[Count]
            WHERE
                {SqlPatterns.Where}
            ORDER BY 1 DESC
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListCustomerJobsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListCustomerJobs parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobWithStatusPoco>();
            builder.AddJoin<JobWithStatusPoco>();
            builder.AddConditions<JobWithStatusPoco>(
                i => i.OrganizationId == parameter.OrganizationId && i.CustomerId == parameter.CustomerId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                customerId = parameter.CustomerId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
