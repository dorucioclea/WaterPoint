using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class CreateJobCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateJobCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateJobQueryParameter parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Job>>();

            builder.Analyze();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
