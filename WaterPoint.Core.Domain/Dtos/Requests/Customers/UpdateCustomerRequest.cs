using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class UpdateCustomerRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteCustomerPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
