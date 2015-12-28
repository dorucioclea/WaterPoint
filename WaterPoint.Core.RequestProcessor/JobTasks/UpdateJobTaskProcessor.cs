using Utility;
using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class UpdateJobTaskProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateJobTaskRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly ICommand<UpdateJobTask> _command;
        private readonly ICommandExecutor<UpdateJobTask> _executor;
        private readonly IQuery<GetJobTask> _query;
        private readonly IQueryRunner<GetJobTask, JobTask> _runner;

        public UpdateJobTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateJobTask> command,
            ICommandExecutor<UpdateJobTask> executor,
            IQuery<GetJobTask> query,
            IQueryRunner<GetJobTask, JobTask> runner)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _command = command;
            _executor = executor;
            _query = query;
            _runner = runner;
        }

        public CommandResultContract Process(UpdateJobTaskRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CommandResultContract ProcessDeFacto(UpdateJobTaskRequest input)
        {
            var getJobTaskParam = new GetJobTask
            {
                JobTaskId = input.Parameter.Id,
                OrganizationId = input.Parameter.OrganizationId,
                JobId = input.Parameter.JobId
            };

            _query.BuildQuery(getJobTaskParam);

            var existingJobTask = _runner.Run(_query);

            var updatedJobTask = _patchEntityAdapter.PatchEnitity<UpdateJobTaskPayload, JobTask, UpdateJobTask>(
                existingJobTask,
                input.Payload.Patch);

            //then build the query to update the object.
            _command.BuildQuery(updatedJobTask);

            var success = _executor.Execute(_command) > 0;

            if (success)
                return new CommandResultContract
                {
                    Message = $"job task {input.Parameter.Id} has been updated",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Message = $"job task {input.Parameter.Id} has not been updated, operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
