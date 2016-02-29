﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "JobCategory", "jc")]
    public class JobCategory : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Description { get; set; }

        public bool IsInternal { get; set; }

        public bool IsCapacityReducing { get; set; }

        public bool IsDeleted { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

        [AutoGenerated]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }

    }

}
