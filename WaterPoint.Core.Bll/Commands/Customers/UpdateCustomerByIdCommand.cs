using WaterPoint.Core.Bll.QueryParameters.Customers;
using WaterPoint.Core.Domain;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    public class UpdateCustomerByIdCommand : ICommand<UpdateCustomerQueryParameter>
    {
        private readonly ISqlBuilderFactory _sqlBuilderFactory;

        public UpdateCustomerByIdCommand(ISqlBuilderFactory sqlBuilderFactory)
        {
            _sqlBuilderFactory = sqlBuilderFactory;
        }

        public void BuildQuery(UpdateCustomerQueryParameter parameter)
        {
            var builder = _sqlBuilderFactory.Create<UpdateSqlBuilder<UpdateCustomerQueryParameter>>();

            builder.Analyze();
            builder.AddValueParameters(parameter);

            builder.AddConditions<Customer>(i => i.OrganizationId == parameter.OrganizationId && i.Id == parameter.Id);

            var sql = builder.GetSql();

            builder.AddParamter("organizationId", parameter.OrganizationId);
            builder.AddParamter("id", parameter.Id);

            Query = sql;

            Parameters = builder.Parameters;
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
