using WaterPoint.Api.Common;
using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Payloads.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class UpdateJobRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<UpdateJobRequest, CommandResultContract>
    {
        private readonly IPatchEntityAdapter _patchEntityAdapter;
        private readonly ICommand<UpdateJob> _updateCommand;
        private readonly ICommandExecutor<UpdateJob> _updateCommandExecutor;
        private readonly IQuery<GetJob> _getJobQuery;
        private readonly IQueryRunner<GetJob, JobWithDetailsPoco> _getJobQueryRunner;

        public UpdateJobRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateJob> updateCommand,
            ICommandExecutor<UpdateJob> updateCommandExecutor,
            IQuery<GetJob> getJobQuery,
            IQueryRunner<GetJob, JobWithDetailsPoco> getJobQueryRunner)
            : base(dapperUnitOfWork)
        {
            _patchEntityAdapter = patchEntityAdapter;
            _updateCommand = updateCommand;
            _updateCommandExecutor = updateCommandExecutor;
            _getJobQuery = getJobQuery;
            _getJobQueryRunner = getJobQueryRunner;
        }

        public CommandResultContract Process(UpdateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return result;
        }

        private CommandResultContract ProcessDeFacto(UpdateJobRequest input)
        {
            _getJobQuery.BuildQuery(new GetJob
            {
                OrganizationId = input.Parameter.OrganizationId,
                JobId = input.Parameter.Id
            });

            var existingJob = _getJobQueryRunner.Run(_getJobQuery);

            var updatedJob = _patchEntityAdapter.PatchEnitity<WriteJobPayload, JobWithDetailsPoco, UpdateJob>(
                existingJob,
                input.Payload.Patch);

            //then build the query to update the object.
            _updateCommand.BuildQuery(updatedJob);

            var success = _updateCommandExecutor.Execute(_updateCommand);

            if (success > 0)
                return new CommandResultContract
                {
                    Message = $"job {input.Parameter.Id} has been updated",
                    Status = CommandResultContract.Success
                };

            return new CommandResultContract
            {
                Message = $"job {input.Parameter.Id} has not been updated, operation is finished but there is no result returned",
                Status = CommandResultContract.Failed
            };
        }
    }
}
