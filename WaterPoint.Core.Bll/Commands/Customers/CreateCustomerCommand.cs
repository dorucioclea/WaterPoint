using Utility;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Customers;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    public class CreateCustomerCommand : ICommand
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateCustomerCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateCustomerPoco input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<CreateCustomerPoco>>();

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
