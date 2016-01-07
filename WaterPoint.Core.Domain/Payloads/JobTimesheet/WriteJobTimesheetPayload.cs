using System;
using System.ComponentModel.DataAnnotations;

namespace WaterPoint.Core.Domain.Payloads.JobTimesheet
{
    public class WriteJobTimesheetPayload : IPayload
    {
        [Required]
        public int? StaffId { get; set; }

        [Required]
        public int? JobTaskId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int Minutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        [Required]
        public bool? IsDuration { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
