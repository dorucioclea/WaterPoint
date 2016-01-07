using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Quotes
{
    public class UpdateQuoteCommand : ICommand<UpdateQuote>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateQuoteCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateQuote parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Quote>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<Quote>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
