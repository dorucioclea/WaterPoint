namespace WaterPoint.Core.Domain.Contracts.InvoiceJobCostItems
{
    public class InvoiceJobCostItemBasicContract : IContract
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int JobCostItemId { get; set; }

        public string ShortDescription { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Quantity { get; set; }

        public bool IsBillable { get; set; }

        public bool Version { get; set; }
    }
}
