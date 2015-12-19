using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.TaskDefinitions
{
    public class GetTaskDefinitionByIdQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetTaskDefinitionByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int taskDefinitionId)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<TaskDefinition>();
            builder.AddConditions<TaskDefinition>(i => i.OrganizationId == orgId && i.Id == taskDefinitionId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                taskDefinitionId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
