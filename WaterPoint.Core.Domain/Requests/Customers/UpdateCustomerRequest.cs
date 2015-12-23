using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Customers
{
    public class UpdateCustomerRequest : IRequest
    {
        public OrgEntityRp Parameter { get; set; }
        public Delta<WriteCustomerPayload> Payload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
