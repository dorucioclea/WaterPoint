using WaterPoint.Core.Domain.Dtos.RequestParameters;
using WaterPoint.Core.Domain.Dtos.Requests.Shared;

namespace WaterPoint.Core.Domain.Dtos.Requests.Jobs
{
    public class ListJobsRequest : ListWithOrgIdRequest
    {
        public JobStatusRp JobStatusParameter { get; set; }
    }
}
