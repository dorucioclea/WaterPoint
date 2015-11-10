using System;
using System.Collections.Generic;
using System.Diagnostics;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Queries
{
    public class GetCustomerByIdQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                   {SqlPatterns.Where}";

        public GetCustomerByIdQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int customerId)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddPrimaryColumns<BasicCustomerPoco>();
            builder.AddConditions<BasicCustomerPoco>(i => i.OrganizationId == orgId && i.Id == customerId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                orgId,
                customerId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
