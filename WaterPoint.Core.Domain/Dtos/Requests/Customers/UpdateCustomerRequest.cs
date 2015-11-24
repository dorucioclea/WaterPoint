using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Interfaces;
using WaterPoint.Core.Domain.Dtos.Payloads.Customers;

namespace WaterPoint.Core.Domain.Dtos.Requests.Customers
{
    public class UpdateCustomerRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteCustomerPayload> UpdateCustomerPayload { get; set; }
        public int StaffId { get; set; }
    }
}
