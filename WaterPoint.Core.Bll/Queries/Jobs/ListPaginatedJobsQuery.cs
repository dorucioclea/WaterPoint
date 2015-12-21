using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class ListPaginatedJobsQuery : IListPaginatedWithOrgIdQuery<PaginatedJobsQueryParameter>
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
            ORDER BY {SqlPatterns.OrderBy}
            OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListPaginatedJobsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(PaginatedJobsQueryParameter parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobWithCustomerAndStatusPoco>();
            builder.AddJoin<JobWithCustomerAndStatusPoco>();
            builder.AddConditions<JobWithCustomerAndStatusPoco>(i => i.OrganizationId == parameter.OrganizationId);
            builder.AddOrderBy<JobWithCustomerAndStatusPoco>(parameter.Sort, parameter.IsDesc);
            builder.AddContains<JobWithCustomerAndStatusPoco>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                searchTerm = parameter.SearchTerm
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
