﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "JobCostItem", "jci")]
    public class JobCostItem : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int JobId { get; set; }

        public int? CostItemId { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Code { get; set; }

        public decimal UnitCost { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public bool IsBillable { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

        [AutoGenerated]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }

        [AutoGenerated]
        public Guid Uid { get; set; }
    }
}
