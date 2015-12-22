using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Bll.QueryRunners.OAuthClients;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.Dtos.Requests.OAuthClients;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.OAuthClients
{
    public class GetOAuthClientProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>
    {
        private readonly IQuery<GetAuthClient> _query;
        private readonly IQueryRunner<GetAuthClient, OAuthClient> _runner;

        public GetOAuthClientProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetAuthClient> query,
            IQueryRunner<GetAuthClient, OAuthClient> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public OAuthClientContract Process(GetOAuthClientRequest input)
        {
            var parameter = new GetAuthClient
            {
                ClientId = input.ClientId,
                ClientSecret = input.ClientSecret,
                IsInternal = input.IsInternal
            };

            using (DapperUnitOfWork.Begin())
            {
                _query.BuildQuery(parameter);

                var client = _runner.Run(_query);

                var result = OAuthClientMapper.Map(client);

                return result;
            }
        }
    }
}
