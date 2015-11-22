﻿using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.Bll.Queries.Jobs
{
    public class PaginatedJobsQuery : IPaginatedWithOrgIdQuery
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

        public PaginatedJobsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc)
        {
            //var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            //builder.AddTemplate(_sqlTemplate);
            //builder.AddPrimaryColumns<Customer>();
            //builder.AddConditions<Customer>(i => i.OrganizationId == orgId);
            //builder.AddOrderBy<Customer>(orderBy, isDesc);

            //var sql = builder.GetSql();

            //Query = sql;

            //Parameters = new
            //{
            //    orgId,
            //    offset,
            //    pageSize
            //};
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}