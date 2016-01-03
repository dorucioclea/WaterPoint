using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class ListCostItemsRequest : IRequest, IPagination, IOrgId
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
        public int OrganizationId { get; set; }
    }
}
