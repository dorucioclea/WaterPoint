using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using WaterPoint.Core.Domain;
using WaterPoint.Data.DbContext.Dapper;

namespace WaterPoint.Data.DbContext.Dapper
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly string _connectionString;

        public DapperDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var result = new SqlConnection(_connectionString);

            return result;
        }
    }
}
