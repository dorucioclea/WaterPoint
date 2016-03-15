using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.InvoiceCostItems
{
    public class UpdateInvoiceCostItem : IQueryParameter
    {
        public int OrganizationId { get; set; }
        public int InvoiceId { get; set; }
        public int? CostItemId { get; set; }
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Quantity { get; set; }
        public bool IsBillable { get; set; }
    }
}
