﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "TaskDefinition", "td")]
    public class TaskDefinition : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        [IgnoreMappingWhenUpdate]
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public bool IsDeleted { get; set; }

        [AutoGenerated, IgnoreMappingWhenUpdate]
        public byte[] Version { get; set; }

        [AutoGenerated, IgnoreMappingWhenUpdate]
        public Guid Uid { get; set; }

        [AutoGenerated, IgnoreMappingWhenUpdate]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }
    }
}
