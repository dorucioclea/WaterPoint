namespace WaterPoint.Core.Domain.Requests.JobTasks
{
    public class GetJobTaskByIdRequest: IRequest
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int Id { get; set; }
    }
}
