using WaterPoint.Core.Domain.QueryParameters.JobCostItems;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobCostItems
{
    public class GetJobCostItemQuery : IQuery<GetJobCostItem, JobCostItem>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobCostItemQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetJobCostItem parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobCostItem>();
            builder.AddConditions<JobCostItem>(
                i => i.JobId == parameter.JobId && i.Id == parameter.Id && i.IsDeleted == false);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                jobId = parameter.JobId,
                id = parameter.Id
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
