using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
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

            return result;
        }

        private CommandResultContract  ProcessDeFacto(CreateJobRequest input)
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

            var newId = _executor.Execute(_command);

            if (newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"job {newId} has been created",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Data = null,
                Message = "operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
