﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "Job", "j")]
    public class Job : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        [IgnoreMappingWhenUpdate]
        public int OrganizationId { get; set; }

        public int JobStatusId { get; set; }

        public int JobCategoryId { get; set; }

        public string Code { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? DueDate { get; set; }

        public bool ExcludeFromWip { get; set; }

        [AutoGenerated, IgnoreMappingWhenUpdate]
        public byte[] Version { get; set; }

        [AutoGenerated, IgnoreMappingWhenUpdate]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }

        [AutoGenerated]
        public Guid Uid { get; set; }
    }
}
