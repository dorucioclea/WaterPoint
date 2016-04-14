using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class ListJobTimesheet : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
