using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class CreateCostItemRequest : IRequest
    {
        public OrgIdRp OrganizationIdParameter { get; set; }
        public WriteCostItemPayload CreateCustomerPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
