using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.TaskDefinitions
{
    public class UpdateTaskDefinitionCommand : ICommand<UpdateTaskDefinition>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateTaskDefinitionCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateTaskDefinition input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<TaskDefinition>>();

            builder.Analyze(input);
            builder.AddValueParameters(input);

            builder.AddConditions<TaskDefinition>(i => i.OrganizationId == input.OrganizationId && i.Id == input.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
