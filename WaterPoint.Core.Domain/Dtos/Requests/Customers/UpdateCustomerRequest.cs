using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class UpdateCustomerRequest : IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteCustomerPayload> UpdateCustomerPayload { get; set; }
        public int OrganizationUserId { get; set; }
    }
}
