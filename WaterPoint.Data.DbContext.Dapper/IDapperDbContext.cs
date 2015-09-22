using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IDapperDbContext
    {
        IDbConnection Connection { get; }

        IDbTransaction GetTransaction();

        Task<IEnumerable<T>> ListAsync<T>(string sql, object parameters) where T : class;

        Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string storedProcName, object parameters) where T : class;

        Task<int> NonQueryAsync(string sql, object parameters);

        IEnumerable<T> List<T>(string sql, object parameters) where T : class;

        IEnumerable<T> ExecuteStoredProcedure<T>(string storedProcName, object parameters) where T : class;

        int NonQuery(string sql, object parameters);
    }
}
