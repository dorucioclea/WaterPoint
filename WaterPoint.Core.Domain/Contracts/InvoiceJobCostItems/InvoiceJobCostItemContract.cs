namespace WaterPoint.Core.Domain.Contracts.InvoiceJobCostItems
{
    public class InvoiceJobCostItemContract : IContract
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int JobCostItemId { get; set; }

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
