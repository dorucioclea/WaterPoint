﻿using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.JobCostItems
{
    public class WriteJobCostItemPayload : IPayload
    {
        [Range(1, int.MaxValue)]
        public int? CostItemId { get; set; }

        [Required, MaxLength(200)]
        public string ShortDescription { get; set; }

        [MaxLength(2000)]
        public string LongDescription { get; set; }

        public string Code { get; set; }

        [Required]
        public decimal? UnitCost { get; set; }

        [Required]
        public decimal? UnitPrice { get; set; }

        public bool? IsWriteOff { get; set; }

        public decimal Quantity { get; set; }

        public bool? IsBillable { get; set; }

        public bool? IsActual { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
