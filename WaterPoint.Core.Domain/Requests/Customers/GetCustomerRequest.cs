using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class GetCustomerRequest : IRequest, IOrgEntity
    {
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
