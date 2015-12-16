using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using WaterPoint.Data.Entity;

namespace WaterPoint.Data.DbContext.Dapper
{
    public class DapperDbContext : IDapperDbContext
    {
        private IDbTransaction _transaction;
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DapperDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if(_connection==null)
                    _connection = new SqlConnection(_connectionString);

                return _connection;
            }
        }

        public IDbTransaction GetTransaction()
        {
            if (Connection.State != ConnectionState.Open)
                throw new InvalidOperationException("BeginTransaction requires a open connection.");

            _transaction = Connection.BeginTransaction();

            return _transaction;
        }

        public async Task<IEnumerable<T>> ListAsync<T>(string sql, object parameters)
        {
            var result = await FetchAsync<T>(sql, CommandType.Text, parameters);

            return result;
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string storedProcName, object parameters)
        {
            var result = await FetchAsync<T>(storedProcName, CommandType.StoredProcedure, parameters);

            return result;
        }

        public async Task<int> NonQueryAsync(string sql, object parameters)
        {
            var result = await Connection.ExecuteAsync(sql, parameters, null, null, CommandType.Text);

            return result;
        }

        public IEnumerable<T> List<T>(string sql, object parameters)
        {
            var result = Fetch<T>(sql, CommandType.Text, parameters);

            return result;
        }

        public IEnumerable<T> ExecuteStoredProcedure<T>(string storedProcName, object parameters)
        {
            var result = Fetch<T>(storedProcName, CommandType.StoredProcedure, parameters);

            return result;
        }

        public IEnumerable<Tuple<TFirst, TSecond>> ExecuteStoredProcedure<TFirst, TSecond>
            (string sql, string splitOn, object parameters)
        {
            return Fetch<TFirst, TSecond>(sql, splitOn, CommandType.StoredProcedure, parameters);
        }

        public IEnumerable<Tuple<TFirst, TSecond>> List<TFirst, TSecond>(string sql, string splitOn, object parameters)
        {
            return Fetch<TFirst, TSecond>(sql, splitOn, CommandType.Text, parameters);
        }

        public int NonQuery(string sql, object parameters)
        {
            var result = Connection.Execute(sql, parameters, _transaction, null, CommandType.Text);

            return result;
        }

        #region Private methods

        private async Task<IEnumerable<T>> FetchAsync<T>(string sql, CommandType type, object parameters)
        {
            var result = await Connection.QueryAsync<T>(sql, parameters, _transaction, null, type);

            return result;
        }

        private IEnumerable<Tuple<TFirst, TSecond>> Fetch<TFirst, TSecond>(string sql, string splitOn, CommandType type, object parameters)
        {
            var result = Connection.Query<TFirst, TSecond, Tuple<TFirst, TSecond>>
                (sql, Tuple.Create, parameters, _transaction, true, splitOn, null, type);

            return result;
        }

        private IEnumerable<T> Fetch<T>(string sql, CommandType type, object parameters)
        {
            var result = Connection.Query<T>(sql, parameters, _transaction, true, null, type);

            return result;
        }

        #endregion
    }
}
