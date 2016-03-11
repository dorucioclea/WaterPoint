using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.CostItems
{
    public class WriteCostItemPayload : IPayload
    {
        public int? SupplierId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Code { get; set; }

        [Required]
        public int CostItemTypeId { get; set; }

        [Required]
        public int UnitOfMeasurementId { get; set; }

        [Required]
        public decimal? UnitCost { get; set; }

        [Required]
        public decimal? UnitPrice { get; set; }

        [Required]
        public bool? IsBillable { get; set; }
    }
}
