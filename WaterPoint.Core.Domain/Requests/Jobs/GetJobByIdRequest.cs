namespace WaterPoint.Core.Domain.Requests.Jobs
{
    public class GetJobByIdRequest : IRequest
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
