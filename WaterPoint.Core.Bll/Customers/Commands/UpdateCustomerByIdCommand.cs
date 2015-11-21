﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Customers.Commands
{
    public class UpdateCustomerByIdCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateCustomerByIdCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(int orgId, Customer input)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<Customer>>();

            builder.Analyze();
            builder.AddValueParameters(input);

            builder.AddConditions<Customer>(i => i.OrganizationId == orgId && i.Id == input.Id);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
