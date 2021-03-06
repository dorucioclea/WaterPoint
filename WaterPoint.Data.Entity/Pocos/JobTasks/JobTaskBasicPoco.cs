﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.JobTasks
{
    [Table("dbo", "JobTask", "jt")]
    public class JobTaskBasicPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int TaskDefinitionId { get; set; }

        public int DisplayOrder { get; set; }

        public int? EstimatedTimeInMinutes { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public bool IsBillable { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }

        public string ShortDescription { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

        [AutoGenerated]
        public Guid Uid { get; set; }
    }
}
