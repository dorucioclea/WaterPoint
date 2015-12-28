using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class ListJobTasksRequest : IRequest
    {
        public OrgIdJobIdRp Parameter { get; set; }
        public PaginationRp Pagination { get; set; }
    }
}
