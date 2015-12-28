using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.JobCostItems
{
    public class WriteJobCostItemPayload
    {
        [Range(1, int.MaxValue)]
        public int? CostItemId { get; set; }

        [Required, MaxLength(200)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Code { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [Required]
        public bool? IsBillable { get; set; }
    }
}
