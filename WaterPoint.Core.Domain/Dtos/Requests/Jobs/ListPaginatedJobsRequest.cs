using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class ListPaginatedJobsRequest : ListPaginatedWithOrgIdRequest
    {
        public JobStatusParameter JobStatusParameter { get; set; }
    }
}
