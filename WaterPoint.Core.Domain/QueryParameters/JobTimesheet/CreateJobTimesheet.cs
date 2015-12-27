using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class CreateJobTimesheet : IQueryParameter
    {
        public int JobId { get; set; }

        public int JobTimesheetTypeId { get; set; }

        public int CustomerId { get; set; }

        public int JobTaskId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int Minutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool IsBillable { get; set; }

        public bool IsDuration { get; set; }

        public bool IsActual { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
