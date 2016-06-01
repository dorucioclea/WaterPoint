using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters
{
    public class SearchByName : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public string SearchTerm { get; set; }
    }
}
