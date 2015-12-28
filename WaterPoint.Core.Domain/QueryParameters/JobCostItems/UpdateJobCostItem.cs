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

        public int Quantity { get; set; }

        public bool IsBillable { get; set; }
    }
}
