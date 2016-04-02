using System;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Data.Entity.Pocos.Jobs
{
    [Table("dbo", "Job", "j")]
    public class JobWithCustomerAndStatusPoco : IDataEntity
    {
        [Primary]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int JobStatusId { get; set; }
        public int JobCategoryId { get; set; }
        public int? PriorityTypeId { get; set; }
        [SearchableAsEnglish]
        public string Code { get; set; }
        [SearchableAsUnicode]
        public string ShortDescription { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public byte[] Version { get; set; }
        public Guid Uid { get; set; }
        [OneToOne("inner", "dbo", "JobStatus", "Name", "js")]
        public string JobStatus { get; set; }
        [OneToOne("inner", "dbo", "Customer", "CustomerTypeId", "c")]
        public int? CustomerTypeId { get; set; }
        [OneToOne("inner", "dbo", "Customer", "LastName", "c")]
        public string LastName { get; set; }
        [OneToOne("inner", "dbo", "Customer", "FirstName", "c")]
        public string FirstName { get; set; }
        [OneToOne("inner", "dbo", "Customer", "OtherName", "c")]
        public string OtherName { get; set; }
    }
}
