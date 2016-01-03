using WaterPoint.Core.Domain.QueryParameters.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class GetJobByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobByIdRequest, JobDetailsContract>
    {
        private readonly IQuery<GetJob> _query;
        private readonly IQueryRunner<GetJob, JobWithDetailsPoco> _runner;

        public GetJobByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJob> query,
            IQueryRunner<GetJob, JobWithDetailsPoco> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobDetailsContract Process(GetJobByIdRequest input)
        {
            var parameter = new GetJob
            {
                OrganizationId = input.OrganizationId,
                JobId = input.Id
            };

            _query.BuildQuery(parameter);

            using (DapperUnitOfWork.Begin())
            {
                var job = _runner.Run(_query);

                var result = JobMapper.Map(job);

                return result;
            }
        }
    }
}
