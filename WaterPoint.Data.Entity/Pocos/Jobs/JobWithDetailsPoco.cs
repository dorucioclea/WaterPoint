using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Jobs
{
    [Table("dbo", "Job", "j")]
    public class JobWithDetailsPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? PriorityTypeId { get; set; }
        [OneToOne("left", "dbo", "PriorityType", "Description", "p")]
        public string PriorityTypeDescription { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? Budget { get; set; }
        public byte[] Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public Guid Uid { get; set; }
        public int? JobCategoryId { get; set; }
        [OneToOne("left", "dbo", "JobCategory", "Description", "jc")]
        public string JobCategoryDescription { get; set; }
        public int CustomerId { get; set; }

        [OneToOne("inner", "dbo", "Customer", "FirstName", "c")]
        public string CustomerFirstName { get; set; }

        [OneToOne("inner", "dbo", "Customer", "LastName", "c")]
        public string CustomerLastName { get; set; }

        [OneToOne("inner", "dbo", "Customer", "OtherName", "c")]
        public string CustomerOtherName { get; set; }

        public int JobStatusId { get; set; }

        [OneToOne("inner", "dbo", "JobStatus", "Name", "js")]
        public string JobStatusName { get; set; }

        public bool ExcludeFromWip { get; set; }
    }
}
