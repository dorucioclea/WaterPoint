using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using WaterPoint.Data.Repository;


namespace WaterPoint.Data.Repository
{   
    public class RepositoryDapper : IRepository
    {
        private string _connectionString;

        private const string _defaultConnection = "DefaultConnection";

        public RepositoryDapper()
            : this(_defaultConnection)
        {
        }

        public RepositoryDapper(string connectionString)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        public async Task<IEnumerable<T>> ListAsync<T>(string sql, object parameters) where T : class
        {
            var result = await FetchAsync<T>(sql, CommandType.Text, parameters);

            return result;
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string storedProcName, object parameters) where T : class
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
