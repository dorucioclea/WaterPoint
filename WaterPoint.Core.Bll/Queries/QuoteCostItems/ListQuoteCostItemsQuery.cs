using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Data.Entity.Pocos.QuoteCostItems;

namespace WaterPoint.Core.Bll.Queries.QuoteCostItems
{
    public class ListQuoteCostItemsQuery : IQuery<ListQuoteCostItems>
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
                            JOIN dbo.Quote q ON qci.QuoteId = q.Id
                        WHERE
                            {SqlPatterns.Where}
                            AND (q.OrganizationId = @organizationid)
                    )[Count]
                WHERE
                   {SqlPatterns.Where}
                ORDER BY 1 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListQuoteCostItemsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListQuoteCostItems parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<QuoteCostItemBasicPoco>();
            builder.AddConditions<QuoteCostItemBasicPoco>(i => i.QuoteId == parameter.QuoteId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                quoteId = parameter.QuoteId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
