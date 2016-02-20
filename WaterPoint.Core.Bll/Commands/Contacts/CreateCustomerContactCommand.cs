using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;

namespace WaterPoint.Core.Bll.Commands.Contacts
{
    public class CreateCustomerContactCommand : ICommand<CreateCustomerContact>
    {
        public void BuildQuery(CreateCustomerContact input)
        {
            Query = "[dbo].[Add_CustomerContact]";

            Parameters = new
            {
                customerid = input.CustomerId,
                contactid = input.ContactId,
                isprimary = input.IsPrimary
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}