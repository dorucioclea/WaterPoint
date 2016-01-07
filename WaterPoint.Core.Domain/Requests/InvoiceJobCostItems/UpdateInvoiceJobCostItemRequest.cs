using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.InvoiceJobCostItems;

namespace WaterPoint.Core.Domain.Requests.InvoiceJobCostItems
{
    public class UpdateInvoiceJobCostItemRequest : IUpdateRequest<UpdateInvoiceJobCostItemPayload>
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateInvoiceJobCostItemPayload> Payload { get; set; }
    }
}
