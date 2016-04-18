using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.JobCostItems
{
    public class UpdateJobCostItem : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        [IgnoreWhenUpdate]
        public int JobId { get; set; }

        public int? CostItemId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Code { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public bool IsBillable { get; set; }

        public bool? IsWriteOff { get; set; }
        
        public bool? IsActual { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
