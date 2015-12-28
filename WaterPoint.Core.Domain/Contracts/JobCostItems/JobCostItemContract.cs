using System;

namespace WaterPoint.Core.Domain.Contracts.JobCostItems
{
    public class JobCostItemContract : IJobCostItemBasicContract
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int? CostItemId { get; set; }
        public string Code { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public bool IsBillable { get; set; }
        public bool IsActual { get; set; }
        public string Version { get; set; }
        public string Uid { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
