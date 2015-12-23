using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class ListCustomersQuery : IQuery<PaginatedOrgIdIsProspect>
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

        public ListCustomersQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(PaginatedOrgIdIsProspect parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddColumns<Customer>();

            if (parameter.IsProspect.HasValue)
                builder.AddConditions<Customer>(
                    i => i.OrganizationId == parameter.OrganizationId
                         && i.IsDeleted == false
                         && i.IsProspect == parameter.IsProspect);
            else
                builder.AddConditions<Customer>(
                    i => i.OrganizationId == parameter.OrganizationId
                         && i.IsDeleted == false);

            builder.AddOrderBy<Customer>(parameter.Sort, parameter.IsDesc);

            builder.AddContains<Customer>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                searchTerm = parameter.SearchTerm,
                isProspect = parameter.IsProspect
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
