using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.CostItems
{
    public class GetCostItemRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
    }
}
