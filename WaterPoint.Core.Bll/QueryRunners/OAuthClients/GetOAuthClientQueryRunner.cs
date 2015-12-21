using System.Linq;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.OAuthClients
{
    public class GetOAuthClientQueryRunner : IQueryRunner<GetAuthClientQueryParameter, OAuthClient>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetOAuthClientQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public OAuthClient Run(IQuery<GetAuthClientQueryParameter> query)
        {
            var client = _dapperDbContext
                .List<OAuthClient>(query.Query, query.Parameters)
                .SingleOrDefault();

            return client;
        }
    }
}
