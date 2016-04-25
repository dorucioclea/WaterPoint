using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Pocos.JobTasks;

namespace WaterPoint.Core.Bll.Queries.JobTasks
{
    public class ListJobTasksQuery : IQuery<ListJobTasks, JobTaskBasicPoco>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    JOIN [dbo].[Job] J ON jt.JobId = j.Id
                WHERE
                    {SqlPatterns.Where}
                    AND j.OrganizationId = @organizationid ";

        public ListJobTasksQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListJobTasks parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobTaskBasicPoco>();
            builder.AddConditions<JobTaskBasicPoco>(i => i.JobId == parameter.JobId && i.IsDeleted == false);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                jobId = parameter.JobId
            };
        }

        public bool IsStoredProcedure => false;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
