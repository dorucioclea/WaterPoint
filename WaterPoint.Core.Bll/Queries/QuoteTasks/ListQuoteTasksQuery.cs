using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.QuoteTasks;

namespace WaterPoint.Core.Bll.Queries.QuoteTasks
{
    public class ListQuoteTasksQuery : IQuery<ListQuoteTasks, QuoteTaskBasicPoco>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.[Quote] q ON qt.QuoteId = q.Id
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                            AND (q.OrganizationId = @organizationid)
                    )[Count]
                WHERE
                    {SqlPatterns.Where}
                    AND (q.OrganizationId = @organizationid)
                ORDER BY 1 DESC
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListQuoteTasksQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListQuoteTasks parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<QuoteTaskBasicPoco>();
            builder.AddConditions<QuoteTaskBasicPoco>(i => i.QuoteId == parameter.QuoteId);

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
