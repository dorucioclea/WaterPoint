namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class GetCostItemRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
    }
}
