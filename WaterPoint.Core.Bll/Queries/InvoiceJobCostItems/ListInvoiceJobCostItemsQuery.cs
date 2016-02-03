using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems;
using WaterPoint.Data.Entity.Pocos.InvoiceJobCostItems;

namespace WaterPoint.Core.Bll.Queries.InvoiceJobCostItems
{
    public class ListInvoiceJobCostItemsQuery : IQuery<ListInvoiceJobCostItems, InvoiceJobCostItemBasicPoco>
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
                            JOIN dbo.Invoice q ON qci.InvoiceId = q.Id
                        WHERE
                            {SqlPatterns.Where}
                            AND (q.OrganizationId = @organizationid)
                    )[Count]
                WHERE
                   {SqlPatterns.Where}
                ORDER BY 1 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListInvoiceJobCostItemsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListInvoiceJobCostItems parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceJobCostItemBasicPoco>();
            builder.AddConditions<InvoiceJobCostItemBasicPoco>(i => i.InvoiceId == parameter.InvoiceId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                quoteId = parameter.InvoiceId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
