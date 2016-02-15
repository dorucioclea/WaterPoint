using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace WaterPoint.ElasticSearch.Worker
{
    class Indexer
    {
        private readonly ElasticClient _client;

        public Indexer(ElasticClient client)
        {
            _client = client;
        }

        public void Run()
        {
            //var descriptor = new BulkDescriptor();

            //var request = new BulkRequest("index name", "type name");

            //foreach (var c in changes)
            //{
            //    var change = c;
            //    switch (change.ChangeType)
            //    {
            //        case ChangeType.Upsert:
            //            descriptor.Index<TDocument>(doc => doc
            //                .Document(change.Document)
            //                .Index(indexName)
            //                .Routing(change.Document.AccountId.ToString(CultureInfo.InvariantCulture)));
            //            break;
            //        case ChangeType.Delete:
            //            descriptor.Delete<TDocument>(doc => doc
            //                .Document(change.Document)
            //                .Index(indexName));
            //            break;
            //    }
            //}

            //var response = await _client.Bulk(des)

            //if (response.Errors)
            //{
            //    var errors = response.ItemsWithErrors
            //        .Select(e => new Exception(e.Error))
            //        .ToList();
            //    throw new AggregateException(
            //        string.Format(
            //            "Error writing changes to Elasticsearch index: {0} - {1} items with errors out of {2} in bulk call.",
            //            indexName, errors.Count, response.Items.Count()),
            //        errors);
            //}
        }
    }
}
