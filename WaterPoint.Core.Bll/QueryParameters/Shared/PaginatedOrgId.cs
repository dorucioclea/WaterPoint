using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Bll.QueryParameters.Shared
{
    public class PaginatedOrgId : IPaginatedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
