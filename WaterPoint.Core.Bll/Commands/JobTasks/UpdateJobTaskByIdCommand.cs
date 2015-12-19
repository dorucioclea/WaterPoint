using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.JobTasks
{
    public class UpdateJobTaskByIdCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobTaskByIdCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(JobTask input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<JobTask>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            builder.AddConditions<JobTask>(i => i.Id == input.Id);

            var sql = builder.GetSql();

            builder.AddParamter("id", input.Id);

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
