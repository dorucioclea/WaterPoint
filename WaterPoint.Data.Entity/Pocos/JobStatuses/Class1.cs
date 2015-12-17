using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.JobStatuses
{
    [Table("dbo", "JobStatus", "jstus")]
    public class JobStatus
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

        public byte[] Version { get; set; }

        public DateTime UtcCreated { get; set; }

        public DateTime UtcUpdated { get; set; }
    }
}
