using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Bll.QueryRunners.OAuthClients;
using WaterPoint.Core.RequestProcessor.Mappers.EntitiesToContracts;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Dtos.Requests.OAuthClients;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.RequestProcessor.OAuthClients
{
    public class GetOAuthClientRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>
    {
        private readonly IQuery<GetAuthClientQueryParameter> _query;
        private readonly IQueryRunner<GetAuthClientQueryParameter, OAuthClient> _runner;

        public GetOAuthClientRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            IQuery<GetAuthClientQueryParameter> query,
            IQueryRunner<GetAuthClientQueryParameter, OAuthClient> runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public OAuthClientContract Process(GetOAuthClientRequest input)
        {
            var parameter = new GetAuthClientQueryParameter
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
