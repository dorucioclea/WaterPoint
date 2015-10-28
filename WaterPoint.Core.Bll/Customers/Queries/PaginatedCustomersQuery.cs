using System;
using System.Collections.Generic;
using System.Diagnostics;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Queries
{
    public class PaginatedBasicCustomerPocosQuery : IQuery
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

        public PaginatedBasicCustomerPocosQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddPrimaryColumns<BasicCustomerPoco>();
            builder.AddConditions<BasicCustomerPoco>(i => i.OrganizationId == orgId);
            builder.AddOrderBy<BasicCustomerPoco>(orderBy, isDesc);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                offset,
                pageSize
            };
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
