namespace WaterPoint.Core.Domain.Contracts.InvoiceCostItems
{
    public class InvoiceCostItemContract : IContract
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int? CostItemId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Quantity { get; set; }

        public bool IsBillable { get; set; }

        public string Version { get; set; }
    }
}
