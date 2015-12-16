using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class ListPaginatedCustomersQuery : IListPaginatedWithOrgIdQuery
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

        public void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc, string searchTerm)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddPrimaryColumns<Customer>();
            builder.AddConditions<Customer>(
                i => i.OrganizationId == orgId && i.IsDeleted == false && i.IsProspect == false);
            builder.AddOrderBy<Customer>(orderBy, isDesc);
            builder.AddContains<Customer>(searchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                offset,
                pageSize,
                searchTerm
            };
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
