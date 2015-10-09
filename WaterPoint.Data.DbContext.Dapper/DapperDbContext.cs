using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace WaterPoint.Data.DbContext.Dapper
{
    public class DapperDbContext : IDapperDbContext
    {
        private IDbTransaction _transaction;

        public DapperDbContext(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection { get; private set; }

        public IDbTransaction GetTransaction()
        {
            if (Connection.State != ConnectionState.Open)
                throw new InvalidOperationException("BeginTransaction requires a open connection.");

            if (_transaction != null)
                throw new InvalidOperationException("There is already one transaction.");

            _transaction = Connection.BeginTransaction();

            return _transaction;
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

        public async Task<int> NonQueryAsync(string sql, object parameters)
        {
            var result = await Connection.ExecuteAsync(sql, parameters, null, null, CommandType.Text);

            return result;
        }

        public IEnumerable<T> List<T>(string sql, object parameters) where T : class
        {
            var result = Fetch<T>(sql, CommandType.Text, parameters);

            return result;
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(string storedProcName, object parameters) where T : class
        {
            var result = Fetch<T>(storedProcName, CommandType.StoredProcedure, parameters);

            return result;
        }

        public int NonQuery(string sql, object parameters)
        {
            var result = Connection.Execute(sql, parameters, _transaction, null, CommandType.Text);

            return result;
        }

        #region Private methods

        private async Task<IEnumerable<T>> FetchAsync<T>(string sql, CommandType type, object parameters) where T : class
        {
            var result = await Connection.QueryAsync<T>(sql, parameters, _transaction, null, type);

            return result;
        }

        private IEnumerable<T> Fetch<T>(string sql, CommandType type, object parameters) where T : class
        {
            var result = Connection.Query<T>(sql, parameters, _transaction, true, null, type);

            return result;
        }

        #endregion
    }
}
