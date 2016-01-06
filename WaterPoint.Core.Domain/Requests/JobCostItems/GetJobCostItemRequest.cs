namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class GetJobCostItemRequest : IRequest
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int Id { get; set; }
    }
}
