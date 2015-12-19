using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class GetJobByIdQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetJobByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int jobId)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<Job>();
            builder.AddConditions<Job>(i => i.OrganizationId == orgId && i.Id == jobId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                jobId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
