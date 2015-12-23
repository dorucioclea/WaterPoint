using System.Linq;
using WaterPoint.Core.Domain.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.OAuthClients
{
    public class GetOAuthClientQueryRunner : IQueryRunner<GetAuthClient, OAuthClient>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public GetOAuthClientQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public OAuthClient Run(IQuery<GetAuthClient> query)
        {
            var client = _dapperDbContext
                .List<OAuthClient>(query.Query, query.Parameters)
                .SingleOrDefault();

            return client;
        }
    }
}
