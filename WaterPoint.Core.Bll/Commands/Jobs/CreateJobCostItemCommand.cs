using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Jobs
{
    public class CreateJobCostItemCommand: ICommand<CreateJobCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateJobCostItemCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateJobCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<JobCostItem>>();

            builder.Analyze<CreateJobCostItem>();
            builder.AddValueParameters(parameter);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
