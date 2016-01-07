using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.CostItems;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class UpdateCostItemRequest : IUpdateRequest<WriteCostItemPayload>, IOrgEntity
    {
        public Delta<WriteCostItemPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
