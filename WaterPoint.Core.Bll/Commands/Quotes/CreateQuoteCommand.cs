using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Quotes;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Quotes
{
    public class CreateQuoteCommand : ICommand<CreateQuote>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateQuoteCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateQuote input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Quote>>();

            builder.Analyze<CreateQuote>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
