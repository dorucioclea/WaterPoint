﻿using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class GetCustomerByIdQuery : IQuery<GetCustomerQueryParameter>
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

        public void BuildQuery(GetCustomerQueryParameter parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);
            builder.AddColumns<Customer>();
            builder.AddConditions<Customer>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.CustomerId);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                customerId = parameter.CustomerId
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
