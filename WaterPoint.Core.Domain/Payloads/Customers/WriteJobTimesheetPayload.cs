using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Payloads.Customers
{
    public class WriteJobTimesheetPayload
    {
        [Required]
        public int JobTaskId { get; set; }

        [Required]
        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int? Minutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Required]
        public bool? IsBillable { get; set; }

        [Required]
        public bool? IsDuration { get; set; }

        [Required]
        public bool? IsActual { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
