using WaterPoint.Core.Domain.RequestParameters;

namespace WaterPoint.Core.Domain.Requests.InvoiceJobCostItems
{
    public class ListInvoiceJobCostItemsRequest : ISimplePagedRequest
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
