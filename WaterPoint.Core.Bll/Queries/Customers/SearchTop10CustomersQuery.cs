using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Customers;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class SearchTop10CustomersQuery : IQuery<SearchTop10Customers, Customer>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        private readonly string _sqlTemplate = $@"
                SELECT TOP 10
                    {SqlPatterns.Columns}
                FROM
                    {SqlPatterns.FromTable}
                WHERE
                    {SqlPatterns.Where}
                ORDER BY 1 ";

        public SearchTop10CustomersQuery(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }


        public void BuildQuery(SearchTop10Customers parameter)
        {
            var builder = _sqlBuilderFactory.Create<SelectSqlBuilder>();

            builder.AddTemplate(_sqlTemplate);

            builder.AddColumns<Customer>();

            builder.AddContains<Customer>(parameter.SearchTerm);

            var sql = builder.GetSql();

            Query = sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                searchTerm = parameter.SearchTerm
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
