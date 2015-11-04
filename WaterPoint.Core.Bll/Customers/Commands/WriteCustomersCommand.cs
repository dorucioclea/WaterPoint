﻿using WaterPoint.Core.Domain.Requests.Customers;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Customers.Commands
{
    public class CreateCustomersCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateCustomersCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, Customer input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Customer>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();
            
            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }

    }
}