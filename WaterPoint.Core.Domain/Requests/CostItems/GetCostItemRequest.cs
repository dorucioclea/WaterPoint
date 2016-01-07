using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class GetCostItemRequest : IRequest, IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
