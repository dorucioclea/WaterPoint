using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Addresses;

namespace WaterPoint.Core.Bll.Commands.Addresses
{
    public class CreateCustomerAddressCommand : ICommand<CreateCustomerAddress>
    {
        public void BuildQuery(CreateCustomerAddress input)
        {
            Query = "[dbo].[Add_CustomerAddress]";

            Parameters = new
            {
                customerid = input.CustomerId,
                addressId = input.AddressId,
                isprimary = input.IsPrimary,
                ispostaddress = input.IsPostAddress
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}