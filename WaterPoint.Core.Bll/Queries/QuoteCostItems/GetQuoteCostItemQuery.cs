using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteCostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.QuoteCostItems
{
    public class GetQuoteCostItemQuery : IQuery<GetQuoteCostItem, QuoteCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.Quote q ON qci.QuoteId = q.Id
                WHERE
                    {SqlPatterns.Where}
                    AND (q.OrganizationId = @orgnizationid) ";

        public GetQuoteCostItemQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetQuoteCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<QuoteCostItem>();
            builder.AddConditions<QuoteCostItem>(i => i.Id == parameter.Id && i.QuoteId == parameter.QuoteId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                id = parameter.Id,
                quoteid = parameter.QuoteId,
                organizationid = parameter.OrganizationId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
