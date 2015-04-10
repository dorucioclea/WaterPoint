using System.Collections.Generic;
using System.Threading.Tasks;

namespace WaterPoint.Data.DbContext
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters) where T : class;

        Task<IEnumerable<T>> QueryStoredProcedureAsync<T>(string storedProcName, object parameters) where T : class;

        Task<int> NonQuery(string sql, object parameters);
    }

}
