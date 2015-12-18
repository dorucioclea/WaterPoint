using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Jobs
{
    [Table("dbo", "Job", "j")]
    public class JobWithCustomerAndStatusPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        [IgnoreMappingWhenUpdate]
        public int OrganizationId { get; set; }
        public int JobStatusId { get; set; }
        public int JobCategoryId { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public byte[] Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public Guid Uid { get; set; }
        [Foreign]
        public string JobStatus { get; set; }
        [Foreign]
        public int? CustomerTypeId { get; set; }
        [Foreign]
        public string LastName { get; set; }
        [Foreign]
        public string FirstName { get; set; }
        [Foreign]
        public string OtherName { get; set; }
        public int TotalCount { get; set; }
    }
}
