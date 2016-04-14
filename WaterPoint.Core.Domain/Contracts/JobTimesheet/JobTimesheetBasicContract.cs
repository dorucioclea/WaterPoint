using System;

namespace WaterPoint.Core.Domain.Contracts.JobTimesheet
{
    public class JobTimesheetBasicContract : IJobTimesheetBasicContract
    {
        public int Id { get; set; }

        public int JobTimesheetTypeId { get; set; }

        public int? JobTaskId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string ShortDescription { get; set; }

        public int OriginalMinutes { get; set; }

        public bool IsWriteOff { get; set; }

        public int RoundedMinutes { get; set; }

        public bool IsBillable { get; set; }

        public bool IsDuration { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }

        public string Version { get; set; }

        public Guid Uid { get; set; }

    }
}
