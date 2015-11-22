using System.Web.Http.OData;
using WaterPoint.Core.Domain.Dtos.Customers.Payloads;
using WaterPoint.Core.Domain.Dtos.Interfaces;

namespace WaterPoint.Core.Domain.Dtos.Customers.Requests
{
    public class UpdateCustomerRequest : IOrganizationEntityParameter, IRequest
    {
        public OrganizationEntityParameter OrganizationEntityParameter { get; set; }
        public Delta<WriteCustomerPayload> UpdateCustomerPayload { get; set; }
        public int StaffId { get; set; }
    }
}
