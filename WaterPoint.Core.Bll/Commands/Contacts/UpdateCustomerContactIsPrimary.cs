using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;

namespace WaterPoint.Core.Bll.Commands.Contacts
{
    public class UpdateCustomerContactIsPrimaryCommand:  ICommand<UpdateCustomerContactIsPrimary>
    {    
        public void BuildQuery(UpdateCustomerContactIsPrimary parameter)
        {
            Query = "[dbo].[Update_CustomerContact_IsPrimary]";

            Parameters = new
            {
                contactid = parameter.ContactId,
                organizationid = parameter.OrganizationId,
                customerid = parameter.CustomerId,
                isprimary = parameter.IsPrimary
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => true;
    }
}
