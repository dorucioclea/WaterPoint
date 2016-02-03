using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobTimesheet;
using WaterPoint.Core.Domain.QueryParameters.JobTimesheet;
using WaterPoint.Core.Domain.Requests.JobTimesheet;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.Timesheet
{
    public class UpdateJobTimesheetProcessor
        : BaseUpdateProcessor<UpdateJobTimesheetRequest, WriteJobTimesheetPayload, UpdateJobTimesheet, GetJobTimesheet, JobTimesheet>
    {
        public UpdateJobTimesheetProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter adapter,
            IQuery<GetJobTimesheet, JobTimesheet> query,
            IQueryRunner runner,
            ICommand<UpdateJobTimesheet> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, adapter, query, runner, command, executor)
        {
        }

        public override GetJobTimesheet BuildGetParameter(UpdateJobTimesheetRequest input)
        {
            var getJobTimesheetParam = new GetJobTimesheet
            {
                Id = input.Id,
                JobId = input.JobId,
                OrganizationId = input.OrganizationId
            };

            return getJobTimesheetParam;
        }
    }
}
