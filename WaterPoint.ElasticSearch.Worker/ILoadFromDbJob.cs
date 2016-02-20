using System.Collections.Generic;
using WaterPoint.ElasticSearch.Worker.Entities;

namespace WaterPoint.ElasticSearch.Worker
{
    public interface ILoadFromDbJob<out T> where T : ISearableEntity
    {
        IEnumerable<T> Fetch(string query, int? lastId, int batchSize);
    }
}
