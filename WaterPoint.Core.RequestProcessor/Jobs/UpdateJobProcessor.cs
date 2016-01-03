using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.Jobs;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class UpdateJobRequestProcessor :
        BaseDapperUowRequestProcess,
        IWriteRequestProcessor<UpdateJobRequest>
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

        public CommandResult Process(UpdateJobRequest input)
        {
            var result = UowProcess(ProcessDeFacto, input);

            return new CommandResult(result, "job", result > 0);
        }

        private int ProcessDeFacto(UpdateJobRequest input)
        {
            _getJobQuery.BuildQuery(new GetJob
            {
                OrganizationId = input.OrganizationId,
                JobId = input.Id
            });

            var existingJob = _getJobQueryRunner.Run(_getJobQuery);

            var updatedJob = _patchEntityAdapter.PatchEnitity<WriteJobPayload, JobWithDetailsPoco, UpdateJob>(
                existingJob,
                input.Payload.Patch);

            //then build the query to update the object.
            _updateCommand.BuildQuery(updatedJob);

            return _updateCommandExecutor.Execute(_updateCommand);
        }
    }
}
