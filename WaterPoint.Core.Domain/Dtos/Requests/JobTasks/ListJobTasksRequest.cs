namespace WaterPoint.Core.Domain.Dtos.Requests.JobTasks
{
    public class ListJobTasksRequest
    {
        public OrgIdParameter OrganizationId { get; set; }
        public PaginationParamter Pagination { get; set; }
    }
}
