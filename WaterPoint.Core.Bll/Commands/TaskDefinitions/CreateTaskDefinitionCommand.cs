using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.TaskDefinitions
{
    public class CreateTaskDefinitionCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateTaskDefinitionCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, TaskDefinition input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<TaskDefinition>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
