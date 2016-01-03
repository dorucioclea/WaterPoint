using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class UpdateCustomerRequest : IRequest, IOrgEntity
    {
        public Delta<WriteCustomerPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
