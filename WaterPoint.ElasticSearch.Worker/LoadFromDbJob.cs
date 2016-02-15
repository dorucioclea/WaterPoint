using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using WaterPoint.ElasticSearch.Worker.Entities;

namespace WaterPoint.ElasticSearch.Worker
{
    public class LoadFromDbJob<T> : ILoadFromDbJob<T> where T : ISearableEntity
    {
        private readonly IDbConnection _connection;

        public LoadFromDbJob(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<T> Fetch(string query, int? lastId, int batchSize)
        {
            var result = _connection.Query<T>(query,
                new { lastid = lastId, batchSize },
                commandType: CommandType.StoredProcedure
                );

            return result;
        }
    }
}
