using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.Requests.TaskDefinitions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
{
    public class UpdateTaskDefinitionProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateTaskDefinitionRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly IQuery<GetTaskDefinition> _getTaskDefinitionByIdQuery;
        private readonly IQueryRunner<GetTaskDefinition, TaskDefinition> _getTaskDefinitionByIdQueryRunner;
        private readonly ICommand<UpdateTaskDefinition> _updateCommand;
        private readonly ICommandExecutor<UpdateTaskDefinition> _updateCommandExecutor;

        public UpdateTaskDefinitionProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            IQuery<GetTaskDefinition> getTaskDefinitionByIdQuery,
            IQueryRunner<GetTaskDefinition, TaskDefinition> getTaskDefinitionByIdQueryRunner,
            ICommand<UpdateTaskDefinition> updateCommand,
            ICommandExecutor<UpdateTaskDefinition> updateCommandExecutor)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _getTaskDefinitionByIdQuery = getTaskDefinitionByIdQuery;
            _getTaskDefinitionByIdQueryRunner = getTaskDefinitionByIdQueryRunner;
            _updateCommand = updateCommand;
            _updateCommandExecutor = updateCommandExecutor;
        }

        public CommandResultContract Process(UpdateTaskDefinitionRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResultContract(result, "task definition", result > 0);
        }

        private int ProcessDeFacto(UpdateTaskDefinitionRequest input)
        {
            _getTaskDefinitionByIdQuery.BuildQuery(new GetTaskDefinition
            {
                OrganizationId = input.Parameter.OrganizationId,
                TaskDefinitionId = input.Parameter.Id
            });

            var existingTaskDefinition = _getTaskDefinitionByIdQueryRunner.Run(_getTaskDefinitionByIdQuery);

            var updatedTaskDefinition = _patchEntityAdapter
                .PatchEnitity<WriteTaskDefinitionPayload, TaskDefinition, UpdateTaskDefinition>(existingTaskDefinition,
                input.Payload.Patch);

            //then build the query to update the object.
            _updateCommand.BuildQuery(updatedTaskDefinition);

            return _updateCommandExecutor.Execute(_updateCommand);
        }
    }



}
