using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.JobTasks
{
    public class CreateJobTaskCommand : ICommand<CreateJobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateJobTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateJobTask input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<JobTask>>();

            builder.Analyze<CreateJobTask>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
