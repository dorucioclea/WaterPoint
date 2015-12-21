using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class GetJobByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobByIdRequest, JobWithDetailsContract>
    {
        private readonly IQuery<GetJobDetails> _query;
        private readonly IQueryRunner<GetJobDetails, JobWithDetailsPoco> _runner;

        public GetJobByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJobDetails> query,
            IQueryRunner<GetJobDetails, JobWithDetailsPoco> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobWithDetailsContract Process(GetJobByIdRequest input)
        {
            var parameter = new GetJobDetails
            {
                OrganizationId = input.OrganizationEntityParameter.OrganizationId,
                JobId = input.OrganizationEntityParameter.Id
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
