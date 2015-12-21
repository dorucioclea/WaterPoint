using WaterPoint.Core.Domain.Db;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        IDapperDbContext DbContext { get; }
    }
}
