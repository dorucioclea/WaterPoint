using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class CreateJobCommand : ICommand<CreateJob>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateJobCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateJob parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Job>>();

            builder.Analyze<CreateJob>();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
