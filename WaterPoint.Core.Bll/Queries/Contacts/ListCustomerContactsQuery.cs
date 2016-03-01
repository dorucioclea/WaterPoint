using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Contacts;
using WaterPoint.Data.Entity.DataEntities;
using WaterPoint.Data.Entity.Pocos.Contacts;

namespace WaterPoint.Core.Bll.Queries.Contacts
{
    public class ListCustomerContactsQuery : IQuery<ListCustomerContacts, CustomerContactPoco>
    {
        public void BuildQuery(ListCustomerContacts parameter)
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
