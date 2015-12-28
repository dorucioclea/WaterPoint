using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class GetJobTimesheet : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int Id { get; set; }
    }
}
