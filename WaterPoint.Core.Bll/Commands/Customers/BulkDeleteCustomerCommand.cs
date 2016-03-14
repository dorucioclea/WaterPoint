using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Customers;

namespace WaterPoint.Core.Bll.Commands.Customers
{
    namespace WaterPoint.Core.Bll.Commands.Customers
    {
        public class BulkDeleteCustomerCommand : ICommand<BulkDeleteCustomer>
        {
            public void BuildQuery(BulkDeleteCustomer parameter)
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
}
