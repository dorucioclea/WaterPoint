using WaterPoint.Core.Domain.Dtos.Payloads.CostItems;

namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class CreateCostItemRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public WriteCostItemPayload CreateCustomerPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
