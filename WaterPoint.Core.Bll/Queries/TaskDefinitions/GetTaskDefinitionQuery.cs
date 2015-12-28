using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.TaskDefinitions
{
    public class GetTaskDefinitionQuery : IQuery<GetTaskDefinition>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetTaskDefinitionQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetTaskDefinition parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddColumns<TaskDefinition>();

            builder.AddConditions<TaskDefinition>(i =>
                i.OrganizationId == parameter.OrganizationId && i.Id == parameter.TaskDefinitionId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                taskDefinitionId = parameter.TaskDefinitionId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
