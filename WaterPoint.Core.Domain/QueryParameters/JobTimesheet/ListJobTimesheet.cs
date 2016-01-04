using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class ListJobTimesheet : ISimplePagedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
    }
}
