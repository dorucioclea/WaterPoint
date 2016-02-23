using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Addresses
{
    public class GetAddressForCustomerQuery : IQuery<GetAddressForCustomer, Address>
    {
        public void BuildQuery(GetAddressForCustomer parameter)
        {
            Query = "[dbo].[Get_CustomerAddress_By_CustomerId]";

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                customerid = parameter.CustomerId,
                id = parameter.Id
            };
        }

        public bool IsStoredProcedure => true;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
