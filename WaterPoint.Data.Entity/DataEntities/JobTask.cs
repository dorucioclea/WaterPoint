﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "JobTask", "jt")]
    public class JobTask : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int JobId { get; set; }

        public int TaskDefinitionId { get; set; }

        public int DisplayOrder { get; set; }

        public int? EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsAllocated { get; set; }

        public bool IsScheduled { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

        [AutoGenerated]
        public Guid Uid { get; set; }

        [AutoGenerated]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }
    }
}
