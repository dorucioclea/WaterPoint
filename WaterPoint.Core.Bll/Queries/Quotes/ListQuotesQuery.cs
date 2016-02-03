using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.Quotes;

namespace WaterPoint.Core.Bll.Queries.Quotes
{
    public class ListQuotesQuery : IQuery<ListQuotes, QuoteBasicPoco>
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
                ORDER BY 1 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListQuotesQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListQuotes parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<QuoteBasicPoco>();
            builder.AddConditions<QuoteBasicPoco>(i => i.OrganizationId == parameter.OrganizationId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
