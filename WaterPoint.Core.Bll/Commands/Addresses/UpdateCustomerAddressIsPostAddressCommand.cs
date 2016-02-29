using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;

namespace WaterPoint.Core.Bll.Commands.Addresses
{
    public class UpdateCustomerAddressIsPostAddressCommand : ICommand<UpdateCustomerAddressIsPostAddress>
    {
        public void BuildQuery(UpdateCustomerAddressIsPostAddress parameter)
        {
            Query = "[dbo].[Update_CustomerAddress_IsPostAddress]";

            Parameters = new
            {
                addressid = parameter.AddressId,
                organizationid = parameter.OrganizationId,
                customerid = parameter.CustomerId,
                ispostaddress = parameter.IsPostAddress
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}