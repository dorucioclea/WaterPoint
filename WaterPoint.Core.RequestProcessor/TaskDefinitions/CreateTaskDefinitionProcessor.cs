using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
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

            return new CommandResultContract(result, "task definition", result > 0);
        }

        private int ProcessDeFacto(CreateTaskDefinitionRequest input)
        {
            var parameter = new CreateTaskDefinition
            {
                OrganizationId = input.OrganizationId.OrganizationId,
                ShortDescription = input.Payload.ShortDescription,
                BaseRate = input.Payload.BaseRate.Value,
                BillableRate = input.Payload.BillableRate.Value,
                LongDescription = input.Payload.LongDescription
            };

            _command.BuildQuery(parameter);

            return _executor.Execute(_command);
        }
    }
}
