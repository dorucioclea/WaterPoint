using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Contacts
{
    public class ListContactsForCustomerQuery : IQuery<ListContactsForCustomer, Contact>
    {
        public void BuildQuery(ListContactsForCustomer parameter)
        {
            Query = "[dbo].[List_CustomerContacts_By_CustomerId]";

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
