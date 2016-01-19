using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;

namespace WaterPoint.Core.Bll.Commands.JobTimesheet
{
    public class UpdateJobTimesheetCommand : ICommand<UpdateJobTimesheet>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobTimesheetCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateJobTimesheet parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Data.Entity.DataEntities.JobTimesheet>>();

            builder.Analyze(parameter);

            builder.AddValueParameters(parameter);

            builder.AddConditions<Data.Entity.DataEntities.JobTimesheet>(i => i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
