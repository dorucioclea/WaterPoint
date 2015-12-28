using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTimesheet
{
    public class ListJobTimesheetRequest : IRequest
    {
        public OrgIdJobIdIdRp Parameter { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
