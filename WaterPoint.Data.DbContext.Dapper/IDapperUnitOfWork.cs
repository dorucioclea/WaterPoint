using System.Data;
using WaterPoint.Core.Domain;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IDapperUnitOfWork : IUnitOfWork
    {
        IDapperDbContext DbContext { get; }
    }
}
