using WaterPoint.Core.Bll.QueryParameters.JobTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class CreateJobTaskRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<CreateJobTaskRequest, JobTaskContract>
    {
        private readonly ICommand<CreateJobTask> _command;
        private readonly ICommandExecutor<CreateJobTask> _executor;
        private readonly IQuery<GetJobTask> _query;
        private readonly IQueryRunner<GetJobTask, JobTask> _queryRunner;

        public CreateJobTaskRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            ICommand<CreateJobTask> command,
            ICommandExecutor<CreateJobTask> executor,
            IQuery<GetJobTask> query,
            IQueryRunner<GetJobTask, JobTask> queryRunner)
            : base(dapperUnitOfWork)
        {
            _command = command;
            _executor = executor;
            _query = query;
            _queryRunner = queryRunner;
        }

        public JobTaskContract Process(CreateJobTaskRequest input)
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
                CompletedDate = input.Payload.CompletedDate.Value,
                DisplayOrder = input.Payload.DisplayOrder.Value,
                EndDate = input.Payload.EndDate.Value,
                EstimatedTimeInMinutes = input.Payload.EstimatedTimeInMinutes.Value,
                IsAllocated = input.Payload.IsAllocated.Value,
                IsBillable = input.Payload.IsBillable.Value,
                IsCompleted = input.Payload.IsCompleted.Value,
                IsScheduled = input.Payload.IsScheduled.Value,
                LongDescription = input.Payload.LongDescription,
                ShortDescription = input.Payload.ShortDescription,
                StartDate = input.Payload.StartDate.Value
            };
        }

        private JobTaskContract ProcessDeFacto(CreateJobTaskRequest input)
        {
            _command.BuildQuery(AnalyzeParameter(input));

            var newId = _executor.Execute(_command);

            _query.BuildQuery(new GetJobTask
            {
                JobTaskId = newId
            });

            var jobTask = _queryRunner.Run(_query);

            var result = JobTaskMapper.Map(jobTask);

            return result;
        }
    }
}
