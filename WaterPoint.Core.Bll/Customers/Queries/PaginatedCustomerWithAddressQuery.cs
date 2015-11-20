using System;
using System.Collections.Generic;
using System.Diagnostics;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity;
using WaterPoint.Data.Entity.Attributes;
using WaterPoint.Data.Entity.Pocos;

namespace WaterPoint.Core.Bll.Customers.Queries
{
    public class PaginatedCustomerWithAddressQuery : IQuery
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private string Sql = string.Format(@"
                SELECT
                    {0}
                    ,[TotalCount]
                FROM
                    {1}
                    CROSS APPLY(
                        SELECT COUNT(*) TotalCount
                        FROM
                            {1}
                        WHERE
                            {2}
                    )[Count]
                WHERE
                    {2}
                ORDER BY @orderBy {3}
                OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY  ",
            SqlPatterns.Columns, SqlPatterns.FromTable, SqlPatterns.Where, SqlPatterns.OrderDesc);

        public PaginatedCustomerWithAddressQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(Sql);
            builder.AddPrimaryColumns<BasicCustomerWithPrimaryAddressPoco>();
            builder.AddForeignColumns<AddressPoco>();
            builder.AddManyToManyJoin<AddressPoco>(JoinTypes.LeftJoin,
                "dbo", "CustomerAddress", "ca", "AddressId", "CustomerId");

            builder.AddConditions<CustomerPoco>(i => i.OrganizationId == orgId);


            var sql = Sql
                .Replace(SqlPatterns.Columns, builder.Columns)
                .Replace(SqlPatterns.FromTable, builder.FromTable)
                .Replace(SqlPatterns.Where, builder.Where);

            Debug.WriteLine(sql);

            throw new NotImplementedException();

            Query = string.Format(Sql, "orgId", "orderBy", "offset", "pageSize");

            Parameters = new
            {
                orgId,
                orderBy,
                offset,
                pageSize
            };
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
