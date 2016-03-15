using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.InvoiceCostItems
{
    public class GetInvoiceCostItemRequest : IRequest, IOrgEntity
    {
        public int InvoiceId { get; set; }
        public int OrganizationId { get; set; }
        public int Id { get; set; }
    }
}
