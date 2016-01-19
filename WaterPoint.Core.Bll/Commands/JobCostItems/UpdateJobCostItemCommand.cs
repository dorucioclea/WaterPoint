using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.JobCostItems
{
    public class UpdateJobCostItemCommand : ICommand<UpdateJobCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateJobCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateJobCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<JobCostItem>>();

            builder.Analyze(parameter);
            builder.AddValueParameters(parameter);

            builder.AddConditions<JobCostItem>(i => i.JobId == parameter.JobId && i.Id == parameter.Id);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
