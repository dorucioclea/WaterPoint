using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class ListJobsRequest : IRequest
    {
        public PaginationRp Pagination { get; set; }
        public JobStatusRp Parameter { get; set; }
    }
}
