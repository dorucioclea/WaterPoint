using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    public class CreateCustomerCommand : ICommand<CreateCustomer>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public CreateCustomerCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(CreateCustomer input)
        {
            var builder = _sqlBuilderFactory.Create<CreateSqlBuilder<Customer>>();

            builder.Analyze<CreateCustomer>();
            builder.AddValueParameters(input);

            var sql = builder.GetSql();

            Query = sql;
            Parameters = builder.Parameters;
        }
        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
