using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.CostItems
{
    public class GetCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int CostItemId { get; set; }
    }
}
