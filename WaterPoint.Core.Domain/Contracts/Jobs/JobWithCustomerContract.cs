using System;
using WaterPoint.Core.Domain.Contracts.Customers;
using WaterPoint.Core.Domain.Contracts.JobStatuses;
using WaterPoint.Core.Domain.Dtos;

namespace WaterPoint.Core.Domain.Contracts.Jobs
{
    public class JobWithCustomerContract : IContract
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Version { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcUpdated { get; set; }
        public string Uid { get; set; }
        public CustomerIdNameContract Customer { get; set; }
        public JobStatusIdNameContract JobStatus { get; set; }
    }


}
