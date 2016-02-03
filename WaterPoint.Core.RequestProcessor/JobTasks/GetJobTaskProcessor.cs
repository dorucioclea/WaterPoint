using WaterPoint.Core.Domain.QueryParameters.JobTasks;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.JobTasks;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.JobTasks;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.JobTasks
{
    public class GetJobTaskProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobTaskByIdRequest, JobTaskContract>
    {
        private readonly IQuery<GetJobTask, JobTask> _query;
        private readonly IQueryRunner _runner;

        public GetJobTaskProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJobTask, JobTask> query,
            IQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobTaskContract Process(GetJobTaskByIdRequest input)
        {
            _query.BuildQuery(new GetJobTask
            {
                JobTaskId = input.Id,
                OrganizationId = input.OrganizationId,
                JobId = input.JobId
            });

            using (DapperUnitOfWork.Begin())
            {
                var taskDefinition = _runner.Run(_query);

                var result = JobTaskMapper.Map(taskDefinition);

                return result;
            }
        }
    }
}
