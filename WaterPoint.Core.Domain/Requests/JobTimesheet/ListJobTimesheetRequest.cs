using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class ListJobTimesheetRequest : IRequest, IPagination
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string Sort { get; set; }
        public bool? IsDesc { get; set; }
        public string SearchTerm { get; set; }
    }
}
