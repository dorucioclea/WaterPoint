using WaterPoint.Core.Bll.QueryParameters.Jobs;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.Jobs;
using WaterPoint.Core.Domain.Dtos.Requests.Jobs;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Jobs;

namespace WaterPoint.Core.RequestProcessor.Jobs
{
    public class GetJobByIdRequestProcessor : BaseDapperUowRequestProcess,
        IRequestProcessor<GetJobByIdRequest, JobWithDetailsContract>
    {
        private readonly IQuery<GetJobDetailsQueryParameter> _query;
        private readonly IQueryRunner<GetJobDetailsQueryParameter, JobWithDetailsPoco> _runner;

        public GetJobByIdRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetJobDetailsQueryParameter> query,
            IQueryRunner<GetJobDetailsQueryParameter, JobWithDetailsPoco> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public JobWithDetailsContract Process(GetJobByIdRequest input)
        {
            var parameter = new GetJobDetailsQueryParameter
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
