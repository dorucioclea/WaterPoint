using System;

namespace WaterPoint.Core.Domain.Contracts.JobTimesheet
{
    public interface IJobTimesheetBasicContract : IContract
    {
        decimal BaseRate { get; set; }
        decimal BillableRate { get; set; }
        DateTime? EndDateTime { get; set; }
        int Id { get; set; }
        bool IsBillable { get; set; }
        bool IsDuration { get; set; }
        int? JobTaskId { get; set; }
        int JobTimesheetTypeId { get; set; }
        int RoundedMinutes { get; set; }
        int StaffId { get; set; }
        DateTime? StartDateTime { get; set; }
        Guid Uid { get; set; }
        string Version { get; set; }
    }
}
