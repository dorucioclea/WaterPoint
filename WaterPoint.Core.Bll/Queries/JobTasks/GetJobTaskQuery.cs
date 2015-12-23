using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobTasks
{
    public class GetJobTaskQuery : IQuery<GetJobTask>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobTaskQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetJobTask parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobTask>();
            builder.AddConditions<JobTask>(i => i.Id == parameter.JobTaskId && i.JobId == parameter.JobId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                jobTaskId = parameter.JobTaskId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
