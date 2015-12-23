using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.Bll.QueryParameters.TaskDefinitions;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Core.Domain.Exceptions;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class CreateJobTaskRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobTaskRequest, CommandResultContract>
    {
        private readonly ICommand<CreateJobTask> _command;
        private readonly ICommandExecutor<CreateJobTask> _executor;
        private readonly IQuery<GetTaskDefinition> _getTaskDefQuery;
        private readonly IQueryRunner<GetTaskDefinition, TaskDefinition> _getTaskDefRunner;

        public CreateJobTaskRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobTask> command,
            ICommandExecutor<CreateJobTask> executor,
            IQuery<GetTaskDefinition> getTaskDefQuery,
            IQueryRunner<GetTaskDefinition, TaskDefinition> getTaskDefRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _getTaskDefQuery = getTaskDefQuery;
            _getTaskDefRunner = getTaskDefRunner;
        }

        public CommandResultContract Process(CreateJobTaskRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        public CreateJobTask AnalyzeParameter(CreateJobTaskRequest input)
        {
            return new CreateJobTask
            {
                OrganizationId = input.OrganizationUserId,
                TaskDefinitionId = input.Payload.TaskDefinitionId.Value,
                JobId = input.Payload.JobId.Value,
                CompletedDate = input.Payload.CompletedDate,
                DisplayOrder = input.Payload.DisplayOrder,
                EndDate = input.Payload.EndDate,
                EstimatedTimeInMinutes = input.Payload.EstimatedTimeInMinutes,
                IsBillable = input.Payload.IsBillable.Value,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                StartDate = input.Payload.StartDate,
                BillableRate = input.Payload.BillableRate,
                BaseRate = input.Payload.BaseRate
            };
        }

        private CommandResultContract ProcessDeFacto(CreateJobTaskRequest input)
        {
            _command.BuildQuery(AnalyzeParameter(input));

            var newId = _executor.Execute(_command);

            if (newId > 0)
                return new CommandResultContract
                {
                    Data = newId,
                    Message = $"job task {newId} has been created",
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
