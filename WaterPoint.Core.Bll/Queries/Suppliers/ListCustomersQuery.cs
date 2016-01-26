using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Core.Domain.QueryParameters.Suppliers;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Suppliers
{
    public class ListSuppliersQuery : IQuery<ListSuppliers>
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

        public ListSuppliersQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListSuppliers parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddColumns<Supplier>();

            if (parameter.IsActive.HasValue)
                builder.AddConditions<Supplier>(
                    i => i.OrganizationId == parameter.OrganizationId
                         && i.IsDeleted == false
                         && i.IsActive == parameter.IsActive);
            else
                builder.AddConditions<Supplier>(
                    i => i.OrganizationId == parameter.OrganizationId
                        && i.IsDeleted == false
                        && i.IsActive);

            builder.AddOrderBy<Supplier>(parameter.Sort, parameter.IsDesc);

            builder.AddContains<Supplier>(parameter.SearchTerm);

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

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
