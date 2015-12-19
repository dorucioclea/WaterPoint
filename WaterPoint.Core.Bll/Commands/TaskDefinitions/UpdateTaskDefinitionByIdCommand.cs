using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.TaskDefinitions
{
    public class UpdateTaskDefinitionByIdCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateTaskDefinitionByIdCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, TaskDefinition input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<TaskDefinition>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            builder.AddConditions<TaskDefinition>(i => i.OrganizationId == orgId && i.Id == input.Id);

            var sql = builder.GetSql();

            builder.AddParamter("orgId", orgId);
            builder.AddParamter("id", input.Id);

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
