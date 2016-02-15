using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.ElasticSearch.Worker.Entities;

namespace WaterPoint.ElasticSearch.Worker
{
    public class PushToElasticJob<T> where T : ISearableEntity
    {
        private readonly ILoadFromDbJob<T> _loadJob;

        public PushToElasticJob(ILoadFromDbJob<T> loadJob)
        {
            _loadJob = loadJob;
        }

        public void Push()
        {
            var batchSize = 1000;

            var loadFinished = false;

            int? lastId = null;

            while (!loadFinished)
            {
                var entitiesToPush = _loadJob.Fetch("List_Customers_By_Batch", lastId, batchSize).ToArray();

                loadFinished = entitiesToPush.Length == 0 || entitiesToPush.Length < batchSize;

                if (entitiesToPush.Length > 0)
                {
                    //push to es
                }

                if (!loadFinished)
                    lastId = entitiesToPush.Max(i=>i.Id);
            }
        }
    }
}
