using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Dapper;

namespace WaterPoint.Data.DbContext
{
    public class DapperDbContext : IDbContext
    {
        private string _connectionString;

        private const string DefaultConnection = "DefaultConnection";

        public DapperDbContext()
            : this(DefaultConnection)
        {
        }

        public DapperDbContext(string connectionString)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters) where T : class
        {
            var result = await FetchAsync<T>(sql, CommandType.Text, parameters);

            return result;
        }

        public async Task<T> QueryOneManyAsync<TNested, T>(string sql, object parameters)
            where T : class
            where TNested : class
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    using (var reader = await conn.QueryMultipleAsync(sql, parameters, null, null, CommandType.Text))
                    {
                        var result = reader.Read<T>().SingleOrDefault();

                        var nested = reader.Read<TNested>().ToList();

                        //if (result != null)
                        return result;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public async Task<IEnumerable<T>> QueryStoredProcedureAsync<T>(string storedProcName, object parameters) where T : class
        {
            var result = await FetchAsync<T>(storedProcName, CommandType.StoredProcedure, parameters);

            return result;
        }

        public async Task<int> NonQuery(string sql, object parameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    var result = await conn.ExecuteAsync(sql, parameters, null, null, CommandType.Text);

                    return result;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private async Task<IEnumerable<T>> FetchAsync<T>(string sql, CommandType type, object parameters) where T : class
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                try
                {
                    await conn.OpenAsync().ConfigureAwait(false);

                    var result = await conn.QueryAsync<T>(sql, parameters, null, null, CommandType.Text);

                    return result;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
