//using System;
//using WaterPoint.Api.Common;
//using WaterPoint.Core.Bll.Commands.TaskDefinitions;
//using WaterPoint.Core.Bll.Executors;
//using WaterPoint.Core.Bll.Queries.TaskDefinitions;
//using WaterPoint.Core.Bll.QueryRunners.TaskDefinitions;
//using WaterPoint.Core.Domain;
//using WaterPoint.Core.Domain.Contracts.TaskDefinitions;
//using WaterPoint.Core.Domain.Exceptions;
//using WaterPoint.Core.Domain.Dtos.Payloads.TaskDefinitions;
//using WaterPoint.Core.Domain.Dtos.Requests.TaskDefinitions;
//using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
//using WaterPoint.Data.DbContext.Dapper;
//using WaterPoint.Data.Entity.DataEntities;

//namespace WaterPoint.Core.RequestProcessor.TaskDefinitions
//{
//    public class UpdateTaskDefinitionRequestProcessor :
//        BaseDapperUowRequestProcess,
//        IRequestProcessor<UpdateTaskDefinitionRequest, TaskDefinitionContract>
//    {
//        private readonly IPatchEntityAdapter _patchEntityAdapter;
//        private readonly GetTaskDefinitionByIdQuery _getTaskDefinitionByIdQuery;
//        private readonly GetTaskDefinitionByIdQueryRunner _getTaskDefinitionByIdQueryRunner;
//        private readonly UpdateTaskDefinitionByIdCommand _updateTaskDefinitionByIdQuery;
//        private readonly UpdateCommandExecutor _updateCommandExecutor;

//        public UpdateTaskDefinitionRequestProcessor(
//            IDapperUnitOfWork dapperUnitOfWork,
//            IPatchEntityAdapter patchEntityAdapter,
//            GetTaskDefinitionByIdQuery getTaskDefinitionByIdQuery,
//            GetTaskDefinitionByIdQueryRunner getTaskDefinitionByIdQueryRunner,
//            UpdateTaskDefinitionByIdCommand updateTaskDefinitionByIdQuery,
//            UpdateCommandExecutor updateCommandExecutor)
//            : base(dapperUnitOfWork)
//        {
//            _patchEntityAdapter = patchEntityAdapter;
//            _getTaskDefinitionByIdQuery = getTaskDefinitionByIdQuery;
//            _getTaskDefinitionByIdQueryRunner = getTaskDefinitionByIdQueryRunner;
//            _updateTaskDefinitionByIdQuery = updateTaskDefinitionByIdQuery;
//            _updateCommandExecutor = updateCommandExecutor;
//        }

//        public TaskDefinitionContract Process(UpdateTaskDefinitionRequest input)
//        {
//            var result = UowProcess(ProcessDeFacto, input);

//            return result;
//        }

//        private TaskDefinitionContract ProcessDeFacto(UpdateTaskDefinitionRequest input)
//        {
//            _getTaskDefinitionByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

//            var existingTaskDefinition = _getTaskDefinitionByIdQueryRunner.Run(_getTaskDefinitionByIdQuery);

//            var updatedTaskDefinition = _patchEntityAdapter.PatchEnitity<WriteTaskDefinitionPayload, TaskDefinition>(
//                existingTaskDefinition,
//                input.UpdateTaskDefinitionPayload.Patch,
//                (o) => { o.UtcUpdated = DateTime.UtcNow; },
//                _getTaskDefinitionByIdQuery);

//            //then build the query to update the object.
//            _updateTaskDefinitionByIdQuery.BuildQuery(input.OrganizationEntityParameter.OrganizationId, updatedTaskDefinition);

//            var success = _updateCommandExecutor.Run(_updateTaskDefinitionByIdQuery);

//            if (success)
//                return TaskDefinitionMapper.Map(updatedTaskDefinition);

//            var updateException = new UpdateFailedException();

//            updateException.AddMessage("operation is finished but there is no result returned");

//            throw updateException;
//        }
//    }



//}
