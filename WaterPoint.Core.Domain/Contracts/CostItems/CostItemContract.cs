using System;
using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.Domain.Contracts.CostItems
{
    public class CostItemContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? SupplierId { get; set; }
        public int ShortDescription { get; set; }
        public int LongDescription { get; set; }
        public int Code { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int IsBillable { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Version { get; set; }
        public string Uid { get; set; }
    }
}
