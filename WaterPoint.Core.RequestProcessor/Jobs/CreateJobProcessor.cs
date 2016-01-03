using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobProcessor : BaseDapperUowRequestProcess,
        IWriteRequestProcessor<CreateJobRequest>
    {
        private readonly ICommand<CreateJob> _command;
        private readonly ICommandExecutor<CreateJob> _executor;

        public CreateJobProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJob> command,
            ICommandExecutor<CreateJob> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResult Process(CreateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "job", result > 0);
        }

        private int ProcessDeFacto(CreateJobRequest input)
        {
            var parameter = new CreateJob
            {
                OrganizationId = input.OrganizationId,
                JobStatusId = input.Payload.JobStatusId.Value,
                Code = input.Payload.Code,
                ShortDescription = input.Payload.ShortDescription,
                CustomerId = input.Payload.CustomerId.Value,
                StartDate = input.Payload.StartDate.Value,
                EndDate = input.Payload.EndDate.Value
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
