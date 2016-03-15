using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.InvoiceCostItems
{
    public class ListInvoiceCostItemsRequest : ISimplePagedRequest
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
