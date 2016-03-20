using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.Pocos.Addresses;

namespace WaterPoint.Core.Bll.Queries.Addresses
{
    public class ListCustomerAddressesQuery : IQuery<ListCustomerAddresses, CustomerAddressPoco>
    {
        public void BuildQuery(ListCustomerAddresses parameter)
        {
            Query = "[dbo].[List_CustomerAddesses_By_CustomerId]";

            Parameters = new
            {
                organizationid = parameter.OrganizationId,
                customerid = parameter.CustomerId,
                isdeleted = parameter.IsDeleted
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
