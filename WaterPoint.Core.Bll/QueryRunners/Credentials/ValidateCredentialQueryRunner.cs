using System.Linq;
using WaterPoint.Data.DbContext.Dapper;
using WaterPoint.Data.Entity.DataEntities;

namespace WaterPoint.Core.Bll.QueryRunners.Credentials
{
    public class ValidateCredentialQueryRunner
    {
        private readonly IDapperDbContext _dapperDbContext;

        public ValidateCredentialQueryRunner(IDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public bool Run(IQuery query)
        {
            var result = _dapperDbContext
                .List<bool>(query.Query, query.Parameters)
                .SingleOrDefault();

            return result;
        }
    }
}
