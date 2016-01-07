using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceJobCostItems
{
    public class GetInvoiceJobCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int Id { get; set; }
    }
}
