using System.Collections.Generic;
using WaterPoint.Core.Bll.QueryParameters.Credentials;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Db;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.Pocos.Views;

namespace WaterPoint.Core.Bll.QueryRunners.Credentials
{
    public class ListValidateCredentialsRunner : IQueryCollectionRunner<ListCredentials, IEnumerable<ValidCredential>>
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ListValidateCredentialsRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public IEnumerable<ValidCredential> Run(IQuery<ListCredentials> query)
        {
            var result = _dapperDbContext
                .List<ValidCredential>(query.Query, query.Parameters);

            return result;
        }
    }
}
