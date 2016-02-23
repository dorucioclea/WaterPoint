using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.Bll.Queries.Addresses
{
    public class GetAddressForCustomerQuery : IQuery<GetAddressForCustomer, CustomerAddressPoco>
    {
        public void BuildQuery(GetAddressForCustomer parameter)
        {
            Query = "[dbo].[Get_CustomerAddress_By_CustomerId]";

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                isdeleted = parameter.IsDeleted,
                customerid = parameter.CustomerId,
                id = parameter.Id
            };
        }

        public bool IsStoredProcedure => true;
        public string Query { get; private set; }
        public object Parameters { get; private set; }
    }
}
