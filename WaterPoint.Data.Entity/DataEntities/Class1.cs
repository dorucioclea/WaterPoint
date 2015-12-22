using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "CostItem", "ci")]
    public class CostItem : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        public int? SupplierId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Code { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsBillable { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public byte[] Version { get; set; }
        public Guid Uid { get; set; }
    }
}
