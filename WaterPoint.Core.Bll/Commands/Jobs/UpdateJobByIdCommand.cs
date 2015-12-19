using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class UpdateJobByIdCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobByIdCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, Job input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Job>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            builder.AddConditions<Job>(i => i.OrganizationId == orgId && i.Id == input.Id);

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
