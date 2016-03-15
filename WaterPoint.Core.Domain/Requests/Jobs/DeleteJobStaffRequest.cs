namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class DeleteJobStaffRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
        public int StaffId { get; set; }
    }
}
