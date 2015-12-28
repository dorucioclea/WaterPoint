using System;
using WaterPoint.Core.Domain.Contracts.JobStatuses;


namespace WaterPoint.Core.Domain.Contracts.Jobs
{
    public class JobWithStatusContract : IJobBasicContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Version { get; set; }
        public string Uid { get; set; }
        public JobStatusIdNameContract JobStatus { get; set; }
    }
}
