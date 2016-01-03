using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class ListJobCostItemsRequest : IRequest, IPagination
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
