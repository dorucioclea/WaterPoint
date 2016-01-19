using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.QuoteTasks
{
    public class CreateQuoteTaskCommand : ICommand<CreateQuoteTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateQuoteTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateQuoteTask input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<QuoteTask>>();

            builder.Analyze<CreateQuoteTask>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
