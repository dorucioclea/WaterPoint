using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Customers;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.Queries.Customers
{
    public class SearchCustomerByNameQuery : IQuery<SearchCustomerByName, Customer>
    {
        private const string Sql = @"
            SELECT TOP 20
	            c.[Id]
                ,c.[OrganizationId]
	            ,c.[OrganizationUserId]
                ,c.[LastChangeOrganizationUserId]
                ,c.[CustomerTypeId]
	            ,c.[IsProspect]
	            ,c.[Gender]
                ,c.[Code]
	            ,c.[FirstName]
	            ,c.[LastName]
	            ,c.[OtherName]
                ,c.[Phone]
                ,c.[MobilePhone]
                ,c.[Email]
	            ,c.[Dob]
	            ,c.[IsDeleted]
	            ,c.[InvoiceCustomerId]
                ,c.[Version]
	            ,c.[UtcCreated]
	            ,c.[UtcUpdated]
	            ,c.[Uid]
            FROM
                Customer c
            WHERE
                CONTAINS(c.[SearchName], @searchterm)
                AND c.OrganizationId = @organizationid";

        public void BuildQuery(SearchCustomerByName parameter)
        {
            Query = Sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                searchterm = parameter.SearchTerm
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
