using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class CreateCostItemRequest : ICreateRequest<WriteCostItemPayload>, IOrgId
    {
        public WriteCostItemPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
