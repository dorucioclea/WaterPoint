﻿using System;
using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Core.Domain.QueryParameters.JobTimesheet
{
    public class CreateJobTimesheet : IQueryParameter
    {
        public int OrganizationId { get; set; }

        public int JobId { get; set; }

        public int JobTimesheetTypeId { get; set; }

        public int JobTaskId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int RoundedMinutes { get; set; }

        public int OriginalMinutes { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public bool IsDuration { get; set; }

        public bool IsBillable { get; set; }

        public decimal BaseRate { get; set; }

        public decimal BillableRate { get; set; }
    }
}
