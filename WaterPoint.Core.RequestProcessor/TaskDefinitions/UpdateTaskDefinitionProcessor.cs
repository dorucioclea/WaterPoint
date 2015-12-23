using System;
using System.Windows.Input;
using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.Commands.TaskDefinitions;
using WaterPoint.Core.Bll.Executors;
using WaterPoint.Core.Bll.Queries.TaskDefinitions;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.Bll.QueryRunners.TaskDefinitions;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;
using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
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

            return result;
        }

        private CommandResultContract ProcessDeFacto(UpdateTaskDefinitionRequest input)
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

            var success = _updateCommandExecutor.Execute(_updateCommand);

            if (success > 0)
                return new CommandResultContract
                {
                    Message = $"task definition {input.Parameter.Id} has been updated",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Message = $"job definition {input.Parameter.Id} has not been updated, operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }



}
