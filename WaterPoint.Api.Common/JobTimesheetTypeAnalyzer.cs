using System;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Data.Entity.Enums;

namespace WaterPoint.Api.Common
{
    public static class JobTimesheetAnalyzer
    {
        public static JobTimesheetTypes AnalyzeType(WriteJobTimesheetPayload payload)
        {
            if (payload.IsDuration.Value)
                return JobTimesheetTypes.Draft;

            if (!payload.IsDuration.Value && (!payload.StartDateTime.HasValue || !payload.EndDateTime.HasValue))
                return JobTimesheetTypes.Draft;

            return JobTimesheetTypes.Timesheet;
        }

        public static int AnalyzeOriginalMinute(WriteJobTimesheetPayload payload)
        {
            if (payload.IsDuration.Value)
                return payload.Minutes;

            return Convert.ToInt32((payload.EndDateTime - payload.StartDateTime).Value.TotalMinutes);
        }

        public static int AnalyzeRoundedMinute(WriteJobTimesheetPayload payload)
        {
            var minutes = AnalyzeOriginalMinute(payload);

            //TODO: settings rounded
            if (minutes % 30 > 0)
                minutes = 30 * (minutes / 30) + 30;

            return minutes;
        }
    }
}
