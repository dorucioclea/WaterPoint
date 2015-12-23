using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class UpdateJobCommand : ICommand<UpdateJob>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateJob parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Job>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<Job>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
