using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems;
using WaterPoint.Data.Entity.Pocos.InvoiceCostItems;

namespace WaterPoint.Core.Bll.Queries.InvoiceCostItems
{
    public class ListInvoiceCostItemsQuery : IQuery<ListInvoiceCostItems, InvoiceCostItemBasicPoco>
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

        public ListInvoiceCostItemsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListInvoiceCostItems parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<InvoiceCostItemBasicPoco>();
            builder.AddConditions<InvoiceCostItemBasicPoco>(i => i.InvoiceId == parameter.InvoiceId);

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
