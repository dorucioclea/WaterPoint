using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class SearchCustomerByName : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
