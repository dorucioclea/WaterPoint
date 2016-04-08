using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.JobCostItems
{
    public class ListJobCostItemsRequest : IRequest, IOrgId
    {
        public int OrganizationId { get; set; }
        public int JobId { get; set; }
    }
}
