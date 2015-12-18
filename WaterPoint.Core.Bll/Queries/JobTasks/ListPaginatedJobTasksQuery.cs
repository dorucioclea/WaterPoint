using WaterPoint.Core.Bll.QueryParameters;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobTasks
{
    public class ListPaginatedJobTasksQuery : IListPaginatedWithOrgIdQuery<PaginatedWithOrgIdQueryParameter>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                    ,[TotalCount]
                FROM
                    {SqlPatterns.FromTable}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {SqlPatterns.FromTable}
                        WHERE
                            {SqlPatterns.Where}
                    )[Count]
                WHERE
                   {SqlPatterns.Where}
                ORDER BY {SqlPatterns.OrderBy}
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY  ";

        public ListPaginatedJobTasksQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int jobId, int offset, int pageSize, string orderBy, bool isDesc, string searchTerm)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobTask>();
            builder.AddConditions<JobTask>(i => i.JobId == jobId);
            builder.AddOrderBy<JobTask>(orderBy, isDesc);
            builder.AddContains<JobTask>(searchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                jobId,
                offset,
                pageSize
            };
        }

        public void BuildQuery(PaginatedWithOrgIdQueryParameter parameter)
        {
            throw new System.NotImplementedException();
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
