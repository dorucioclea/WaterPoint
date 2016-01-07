using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.InvoiceJobCostItems
{
    public class CreateInvoiceJobCostItemPayload : IPayload
    {
        [Required]
        public int? JobCostItemId { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Quantity { get; set; }

        [Required]
        public bool? IsBillable { get; set; }
    }
}
