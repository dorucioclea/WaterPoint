using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.QuoteTasks
{
    public class GetQuoteTaskQuery : IQuery<GetQuoteTask, QuoteTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    JOIN dbo.Quote q ON qt.QuoteId = q.Id
                WHERE
                   {SqlPatterns.Where}
                    AND (q.OrganizationId = @organizationid) ";

        public GetQuoteTaskQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetQuoteTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<QuoteTask>();
            builder.AddConditions<QuoteTask>(i => i.Id == parameter.Id && i.QuoteId == parameter.QuoteId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                quoteId = parameter.QuoteId,
                id = parameter.Id,
                organizationid = parameter.OrganizationId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
