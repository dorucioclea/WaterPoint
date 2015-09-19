using System.Data;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.Repositories;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IDapperDbContext
    {
        IDbConnection GetConnection();
    }
}
