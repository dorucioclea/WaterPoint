using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.JobCostItems
{
    public class ListJobCostItemsQuery : IQuery<ListJobCostItems>
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

        public ListJobCostItemsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(ListJobCostItems parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<JobCostItem>();
            builder.AddConditions<JobCostItem>(i => i.JobId == parameter.JobId);
            builder.AddOrderBy<JobCostItem>(parameter.Sort, parameter.IsDesc);
            builder.AddContains<JobCostItem>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                searchTerm = parameter.SearchTerm,
                jobId = parameter.JobId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
