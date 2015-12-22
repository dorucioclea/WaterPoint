namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class ListCostItemsRequest : IRequest
    {
        public OrgIdRp OrganizationId { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
