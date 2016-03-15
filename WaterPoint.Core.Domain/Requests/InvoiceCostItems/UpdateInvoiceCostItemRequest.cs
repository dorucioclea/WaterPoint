using System.Web.Http.OData;
using WaterPoint.Core.Domain.Payloads.InvoiceCostItems;

namespace WaterPoint.Core.Domain.Requests.InvoiceCostItems
{
    public class UpdateInvoiceCostItemRequest : IUpdateRequest<UpdateInvoiceCostItemPayload>
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int Id { get; set; }
        public Delta<UpdateInvoiceCostItemPayload> Payload { get; set; }
    }
}
