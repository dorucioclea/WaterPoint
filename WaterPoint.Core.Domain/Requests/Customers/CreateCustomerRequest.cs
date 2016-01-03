using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class CreateCustomerRequest : IRequest, IOrgId
    {
        public WriteCustomerPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
