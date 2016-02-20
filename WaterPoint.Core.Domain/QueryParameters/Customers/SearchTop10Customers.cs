using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.Customers
{
    public class SearchTop10Customers : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
