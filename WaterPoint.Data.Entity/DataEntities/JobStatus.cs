﻿using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.DataEntities
{
    [Table("dbo", "JobStatus", "jstus")]
    public class JobStatus : IDataEntity
    {
        [Primary]
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrganizationId { get; set; }

        public bool ForPlanned { get; set; }

        public bool ForDeleted { get; set; }

        public bool ForOnHold { get; set; }

        public bool ForCompleted { get; set; }

        public bool ForInProgress { get; set; }

        public bool ForCancelled { get; set; }

        public bool IsDeleted { get; set; }

        public int DisplayOrder { get; set; }

        [AutoGenerated]
        public byte[] Version { get; set; }

        [AutoGenerated]
        public DateTime UtcCreated { get; set; }

        [AutoGenerated]
        public DateTime UtcUpdated { get; set; }
    }
}
