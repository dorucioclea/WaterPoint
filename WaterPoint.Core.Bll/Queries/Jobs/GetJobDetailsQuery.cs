using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class GetJobDetailsQuery : IQuery<GetJob, JobWithDetailsPoco>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                    {SqlPatterns.Join}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobDetailsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(GetJob parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobWithDetailsPoco>();
            builder.AddJoin<JobWithDetailsPoco>();
            builder.AddConditions<JobWithDetailsPoco>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.JobId);

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
