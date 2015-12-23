using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class ListCostItemsRequest : IRequest
    {
        public OrgIdRp OrganizationId { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
