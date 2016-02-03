using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class CreateJobTimesheetProcessor : BaseCreateProcessor<CreateJobTimesheetRequest, CreateJobTimesheet>
    {
        public CreateJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobTimesheet> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CreateJobTimesheet BuildParameter(CreateJobTimesheetRequest input)
        {
            var parameter = new CreateJobTimesheet
            {
                JobTimesheetTypeId = (int)JobTimesheetAnalyzer.AnalyzeType(input.Payload),
                JobId = input.JobId,
                JobTaskId = input.Payload.JobTaskId.Value,
                BillableRate = input.Payload.BillableRate,
                BaseRate = input.Payload.BaseRate,
                ShortDescription = input.Payload.ShortDescription,
                LongDescription = input.Payload.LongDescription,
                IsBillable = input.Payload.IsBillable.Value,
                EndDateTime = input.Payload.EndDateTime,
                IsDuration = input.Payload.IsDuration.Value,
                OriginalMinutes = JobTimesheetAnalyzer.AnalyzeOriginalMinute(input.Payload),
                RoundedMinutes = JobTimesheetAnalyzer.AnalyzeRoundedMinute(input.Payload),
                StaffId = input.Payload.StaffId.Value,
                StartDateTime = input.Payload.StartDateTime
            };

            return parameter;
        }
    }
}
