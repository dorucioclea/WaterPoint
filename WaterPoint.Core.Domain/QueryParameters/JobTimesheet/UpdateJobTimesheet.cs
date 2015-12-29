using System;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.Entity.Attributes;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class UpdateJobTimesheet : IQueryParameter
    {
        [IgnoreWhenUpdate]
        public int Id { get; set; }

        public int JobTimesheetTypeId { get; set; }

        public int JobTaskId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int OriginalMinutes { get; set; }

        public int RoundedMinutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool IsBillable { get; set; }

        public bool IsDuration { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
