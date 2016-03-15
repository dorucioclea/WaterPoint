using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class DeleteJobStaffProcessor :
    BaseDapperUowRequestProcess,
        IWriteRequestProcessor<DeleteJobStaffRequest>
    {
        private readonly ICommand<DeleteJobStaff> _deleteCommand;
        private readonly ICommandExecutor _deleteExecutor;

        public DeleteJobStaffProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<DeleteJobStaff> deleteCommand,
            ICommandExecutor deleteExecutor)
            : base(dapperUnitOfWork)
        {
            _deleteCommand = deleteCommand;
            _deleteExecutor = deleteExecutor;
        }

        public CommandResult Process(DeleteJobStaffRequest input)
        {
            var result = UowProcess(Delete, input);

            return new DeleteCommandResult(result, result > 0);
        }

        private int Delete(DeleteJobStaffRequest input)
        {
            var param = new DeleteJobStaff
            {
                JobId = input.JobId,
                StaffId = input.StaffId,
                OrganizationId = input.OrganizationId
            };

            _deleteCommand.BuildQuery(param);

            return _deleteExecutor.ExecuteNonQuery(_deleteCommand);
        }
    }
}
