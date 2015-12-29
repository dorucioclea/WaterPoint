using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class CreateJobProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobRequest, CommandResultContract>
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

        public CommandResultContract Process(CreateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResultContract(result, "job", result > 0);
        }

        private int ProcessDeFacto(CreateJobRequest input)
        {
            var parameter = new CreateJob
            {
                OrganizationId = input.OrganizationIdParameter.OrganizationId,
                JobStatusId = input.CreateJobPayload.JobStatusId.Value,
                Code = input.CreateJobPayload.Code,
                ShortDescription = input.CreateJobPayload.ShortDescription,
                CustomerId = input.CreateJobPayload.CustomerId.Value,
                StartDate = input.CreateJobPayload.StartDate.Value,
                EndDate = input.CreateJobPayload.EndDate.Value
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
