using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    public class DeleteCustomerCommand : ICommand<DeleteCustomer>
    {
        public void BuildQuery(DeleteCustomer parameter)
        {
            Query = "[dbo].[SoftDelete_Customers]";

            Parameters = new
            {
                organizationid = parameter.OrganizationId,
                customerIds = parameter.Customers
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
