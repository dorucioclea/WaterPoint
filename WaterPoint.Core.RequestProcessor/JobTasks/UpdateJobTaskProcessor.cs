using WaterPoint.Api.Common;
using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Payloads.JobTasks;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class UpdateJobTaskProcessor :
        BaseUpdateProcessor<UpdateJobTaskRequest, UpdateJobTaskPayload, UpdateJobTask, GetJobTask, JobTask>
    {
        public UpdateJobTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IPatchEntityAdapter patchEntityAdapter,
            ICommand<UpdateJobTask> command,
            ICommandExecutor executor,
            IQuery<GetJobTask, JobTask> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork, patchEntityAdapter, query, runner, command, executor)
        {
        }

        public override GetJobTask BuildGetParameter(UpdateJobTaskRequest input)
        {
            var getJobTaskParam = new GetJobTask
            {
                JobTaskId = input.Id,
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            };

            return getJobTaskParam;
        }
    }
}
