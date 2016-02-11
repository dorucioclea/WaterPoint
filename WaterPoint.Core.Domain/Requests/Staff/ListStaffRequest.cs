using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Staff
{
    public class ListStaffRequest : IPaginationRequest
    {
        public int OrganizationId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public bool? IsWorking { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
