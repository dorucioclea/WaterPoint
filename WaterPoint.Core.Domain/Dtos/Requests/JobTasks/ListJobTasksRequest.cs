using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class ListJobTasksRequest : IRequest
    {
        public JobIdOrgIdRp Parameter { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
