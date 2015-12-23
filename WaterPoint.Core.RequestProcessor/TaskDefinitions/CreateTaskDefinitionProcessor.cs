using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class CreateTaskDefinitionProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateTaskDefinitionRequest, CommandResultContract>
    {
        private readonly ICommand<CreateTaskDefinition> _command;
        private readonly ICommandExecutor<CreateTaskDefinition> _executor;

        public CreateTaskDefinitionProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateTaskDefinition> command,
            ICommandExecutor<CreateTaskDefinition> executor)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
        }

        public CommandResultContract Process(CreateTaskDefinitionRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CommandResultContract ProcessDeFacto(CreateTaskDefinitionRequest input)
        {
            var parameter = new CreateTaskDefinition
            {
                OrganizationId = input.OrganizationId.OrganizationId,
                Name = input.Payload.Name,
                BaseRate = input.Payload.BaseRate.Value,
                BillableRate = input.Payload.BillableRate.Value,
                Description = input.Payload.Description
            };

            _command.BuildQuery(parameter);

            var newId = _executor.Execute(_command);

            if (newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"task definition {newId} has been created",
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
