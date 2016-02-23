using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Commands.Addresses
{
    public class UpdateCustomerAddressCommand : ICommand<UpdateCustomerAddress>
    {
        public void BuildQuery(UpdateCustomerAddress parameter)
        {
            Query = "[dbo.[Update_CustomerAddress]";

            Parameters = new
            {
                addressid = parameter.AddressId,
                organizationid = parameter.OrganizationId,
                customerid = parameter.CustomerId,
                isprimary = parameter.IsPrimary,
                ispostaddress = parameter.IsPostAddress
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
