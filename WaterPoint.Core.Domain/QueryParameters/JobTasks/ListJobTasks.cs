using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTasks
{
    public class ListJobTasks : IPaginatedQueryParameter
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string Sort { get; set; }
        public bool IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
