using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.CostItems
{
    public class BulkDeleteCostItems : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public string CostItems { get; set; }
    }
}
