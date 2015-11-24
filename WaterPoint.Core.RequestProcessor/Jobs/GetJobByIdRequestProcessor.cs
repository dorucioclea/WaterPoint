using WaterPoint.Core.Bll.Queries.Jobs;
using WaterPoint.Core.Bll.QueryRunners.Jobs;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class GetJobByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobByIdRequest, JobContract>
    {
        private readonly GetJobByIdQuery _query;
        private readonly GetJobByIdQueryRunner _runner;

        public GetJobByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetJobByIdQuery query,
            GetJobByIdQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobContract Process(GetJobByIdRequest input)
        {
            _query.BuildQuery(input.OrganizationEntityParameter.OrganizationId, input.OrganizationEntityParameter.Id);

            using (DapperUnitOfWork.Begin())
            {
                var job = _runner.Run(_query);

                var result = JobMapper.Map(job);

                return result;
            }
        }
    }
}
