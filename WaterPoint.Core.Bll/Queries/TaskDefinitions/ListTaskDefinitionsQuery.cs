﻿using WaterPoint.Core.Domain.QueryParameters.Shared;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.TaskDefinitions
{
    public class ListTaskDefinitionsQuery : IQuery<PaginatedOrgId>
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

        public ListTaskDefinitionsQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(PaginatedOrgId parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<TaskDefinition>();
            builder.AddConditions<TaskDefinition>(i => i.OrganizationId == parameter.OrganizationId);
            builder.AddOrderBy<TaskDefinition>(parameter.Sort, parameter.IsDesc);
            builder.AddContains<TaskDefinition>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                offset = parameter.Offset,
                pageSize = parameter.PageSize,
                searchTerm = parameter.SearchTerm
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
