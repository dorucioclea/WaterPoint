using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.TaskDefinitions
{
    public class CreateTaskDefinitionCommand : ICommand<CreateTaskDefinition>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateTaskDefinitionCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateTaskDefinition parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<TaskDefinition>>();

            builder.Analyze<CreateTaskDefinition>();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
