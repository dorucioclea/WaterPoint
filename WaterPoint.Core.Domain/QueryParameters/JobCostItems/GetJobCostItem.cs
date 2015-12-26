using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobCostItems
{
    public class GetJobCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int Id { get; set; }
    }
}
