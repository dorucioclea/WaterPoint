namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class ListJobStaffRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
