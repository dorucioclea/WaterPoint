using WaterPoint.Core.Bll.Queries.OAuthClients;
using WaterPoint.Core.Bll.QueryRunners.OAuthClients;
using WaterPoint.Core.ContractMapper;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Contracts.OAuthClients;
using WaterPoint.Core.Domain.Dtos.Requests.OAuthClients;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Core.RequestProcessor.OAuthClients
{
    public class GetOAuthClientRequestProcessor :
        BaseDapperUowRequestProcess,
        IRequestProcessor<GetOAuthClientRequest, OAuthClientContract>
    {
        private readonly GetOAuthClientQuery _query;
        private readonly GetOAuthClientQueryRunner _runner;

        public GetOAuthClientRequestProcessor(
            IDapperUnitOfWork dapperUnitOfWork,
            GetOAuthClientQuery query,
            GetOAuthClientQueryRunner runner)
            : base(dapperUnitOfWork)
        {
            _query = query;
            _runner = runner;
        }

        public OAuthClientContract Process(GetOAuthClientRequest input)
        {
            using (DapperUnitOfWork.Begin())
            {
                _query.BuildQuery(input.ClientId, input.ClientSecret, input.IsInternal);

                var client = _runner.Run(_query);

                var result = OAuthClientMapper.Map(client);

                return result;
            }
        }
    }
}
