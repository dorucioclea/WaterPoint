using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class ListJobsRequest : IRequest, IPagination
    {
        //[RegularExpression(@"\b^((?i)inprogress|cancelled|planned|deleted|onhold|completed?(?-i))$\b")]
        public string Status { get; set; }
        public int OrganizationId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
