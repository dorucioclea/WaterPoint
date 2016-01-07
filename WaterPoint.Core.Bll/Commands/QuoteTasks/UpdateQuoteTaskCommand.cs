using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.QuoteTasks;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.QuoteTasks
{
    public class UpdateQuoteTaskCommand : ICommand<UpdateQuoteTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateQuoteTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateQuoteTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<QuoteTask>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<QuoteTask>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
