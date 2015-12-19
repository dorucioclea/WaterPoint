using WaterPoint.Core.Domain;

namespace WaterPoint.Core.Bll.QueryParameters
{
    public class PaginatedWithOrgIdQueryParameter : IPaginatedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
