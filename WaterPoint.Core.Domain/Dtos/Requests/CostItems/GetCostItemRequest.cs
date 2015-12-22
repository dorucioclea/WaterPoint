namespace WaterPoint.Core.Domain.Dtos.Requests.CostItems
{
    public class GetCostItemRequest : IRequest
    {
        public OrgEntityRp OrganizationEntityParameter { get; set; }
    }
}
