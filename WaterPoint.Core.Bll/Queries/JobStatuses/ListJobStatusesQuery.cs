using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobStatuses
{
    public class ListJobStatusesQuery : IQuery<ListOrgEntities, JobStatus>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}
                ";

        public ListJobStatusesQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListOrgEntities parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobStatus>();
            builder.AddConditions<JobStatus>(i =>
                i.IsDeleted == false && i.OrganizationId == parameter.OrganizationId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationid = parameter.OrganizationId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
