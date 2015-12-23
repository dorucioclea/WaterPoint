using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.CostItems;

namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class UpdateCostItemRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteCostItemPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
