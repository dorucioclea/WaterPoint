using WaterPoint.Core.Domain.Payloads.Suppliers;
using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.Suppliers
{
    public class CreateSupplierRequest : ICreateRequest<CreateSupplierPayload>, IOrgId
    {
        public CreateSupplierPayload Payload { get; set; }
        public int OrganizationUserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
