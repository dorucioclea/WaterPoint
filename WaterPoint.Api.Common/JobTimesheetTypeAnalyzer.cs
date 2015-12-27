using System;
using WaterPoint.Core.Domain.Payloads.Customers;
using WaterPoint.Core.Domain.RequestParameters;
using WaterPoint.Data.Entity.Enums;

namespace WaterPoint.Api.Common
{
    public class JobTimesheetAnalyzer
    {
        public JobTimesheetTypes AnalyzeType(WriteJobTimesheetPayload payload)
        {
            if (payload.IsDuration.Value && !payload.Minutes.HasValue)
                return JobTimesheetTypes.Draft;

            if (!payload.IsDuration.Value && (!payload.StartDateTime.HasValue || !payload.EndDateTime.HasValue))
                return JobTimesheetTypes.Draft;

            return JobTimesheetTypes.Timesheet;
        }

        public int AnalyzeMinute(WriteJobTimesheetPayload payload)
        {
            if (payload.IsDuration.Value)
                return payload.Minutes.Value;

            return Convert.ToInt32((payload.EndDateTime - payload.StartDateTime).Value.TotalMinutes);
        }
    }
}
