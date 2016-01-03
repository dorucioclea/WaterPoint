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
    public class CreateJobTimesheetProcessor : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateJobTimesheetRequest>
    {
        private readonly ICommand<CreateJobTimesheet> _command;
        private readonly ICommandExecutor<CreateJobTimesheet> _executor;
        private readonly JobTimesheetAnalyzer _jobTimesheetTypeAnalyzer;

        public CreateJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobTimesheet> command,
            ICommandExecutor<CreateJobTimesheet> executor,
            JobTimesheetAnalyzer jobTimesheetTypeAnalyzer)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _jobTimesheetTypeAnalyzer = jobTimesheetTypeAnalyzer;
        }

        public CommandResult Process(CreateJobTimesheetRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "job timesheet", result > 0);
        }

        private int ProcessDeFacto(CreateJobTimesheetRequest input)
        {
            var parameter = new CreateJobTimesheet
            {
                JobTimesheetTypeId = (int)_jobTimesheetTypeAnalyzer.AnalyzeType(input.Payload),
                JobId = input.JobId,
                JobTaskId = input.Payload.JobTaskId.Value,
                BillableRate = input.Payload.BillableRate,
                BaseRate = input.Payload.BaseRate,
                ShortDescription = input.Payload.ShortDescription,
                LongDescription = input.Payload.LongDescription,
                IsBillable = input.Payload.IsBillable.Value,
                EndDateTime = input.Payload.EndDateTime,
                IsDuration = input.Payload.IsDuration.Value,
                OriginalMinutes = _jobTimesheetTypeAnalyzer.AnalyzeOriginalMinute(input.Payload),
                RoundedMinutes = _jobTimesheetTypeAnalyzer.AnalyzeRoundedMinute(input.Payload),
                StaffId = input.Payload.StaffId.Value,
                StartDateTime = input.Payload.StartDateTime
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
