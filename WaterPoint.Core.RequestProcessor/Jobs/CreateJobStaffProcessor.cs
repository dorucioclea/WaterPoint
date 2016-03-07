using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobStaffProcessor: BaseCreateProcessor<CreateJobStaffRequest, CreateJobStaff>
        {
        public CreateJobStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobStaff> command,
            ICommandExecutor executor)
            : base(dapperUnitOfWork, command, executor)
        {
        }

        public override CommandResult Process(CreateJobStaffRequest input)
        {
            var result = UowProcess(Execute, input);

            return new ObjectsCountCommandResult(result, result > 0);
        }

        public override CreateJobStaff BuildParameter(CreateJobStaffRequest input)
        {
            return new CreateJobStaff
            {
                OrganizationId = input.OrganizationId,
                JobId = input.JobId,
                StaffIds = input.Payload.StaffIds
            };
        }
    }
}
