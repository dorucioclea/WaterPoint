using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Jobs
{
    [Table("dbo", "Job", "j")]
    public class JobWithStatusPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int JobStatusId { get; set; }
        public int? JobCategoryId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public byte[] Version { get; set; }
        public Guid Uid { get; set; }
        [OneToOne("inner", "dbo", "JobStatus", "Name", "js")]
        public string JobStatusName { get; set; }
    }
}
