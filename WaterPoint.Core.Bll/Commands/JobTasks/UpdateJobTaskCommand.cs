using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.JobTasks
{
    public class UpdateJobTaskCommand : ICommand<UpdateJobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobTaskCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateJobTask input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<JobTask>>();

            builder.Analyze(input);
            builder.AddValueParameters(input);

            builder.AddConditions<JobTask>(i => i.Id == input.Id && i.JobId == input.JobId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
