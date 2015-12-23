using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Core.Domain.Requests.Shared;

namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class ListJobsRequest : ListWithOrgIdRequest
    {
        public JobStatusRp JobStatusParameter { get; set; }
    }
}
