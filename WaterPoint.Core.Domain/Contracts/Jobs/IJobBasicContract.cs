using System;

namespace WaterPoint.Core.Domain.Contracts.Jobs
{
    public interface IJobBasicContract : IContract
    {
        int Id { get; set; }
        int OrganizationId { get; set; }
        string Code { get; set; }
        string ShortDescription { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        DateTime? DueDate { get; set; }
        string Version { get; set; }
        string Uid { get; set; }
    }
}
