using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class ListPaginatedCustomersQuery : IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                ORDER BY {SqlPatterns.OrderBy}
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListPaginatedCustomersQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(PaginatedWithOrgIdQueryParameter parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddPrimaryColumns<Customer>();

            builder.AddConditions<Customer>(
                i => i.OrganizationId == parameter.OrganizationId && i.IsDeleted == false && i.IsProspect == false);

            builder.AddOrderBy<Customer>(parameter.Sort, parameter.IsDesc);

            builder.AddContains<Customer>(parameter.SearchTerm);

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
