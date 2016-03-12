using System;

namespace WaterPoint.Core.Domain.Contracts.CostItems
{
    public class CostItemContract : IContract
    {
        public int Id { get; set; }
        public int CostItemTypeId { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public int OrganizationId { get; set; }
        public int? SupplierId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Code { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsBillable { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Version { get; set; }
        public string Uid { get; set; }
    }
}
