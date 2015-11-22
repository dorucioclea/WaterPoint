using System;

namespace WaterPoint.Core.Domain.Contracts.Jobs
{
    public class JobContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int JobStatusId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
    }
}
