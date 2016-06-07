using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using WaterPoint.ElasticSearch.Docs;

namespace WaterPoint.ElasticSearch.Worker
{
    class IndexingHelper<TDoc> where TDoc: EsDoc
    {
        private readonly ElasticClient _client;

        public IndexingHelper(ElasticClient client)
        {
            _client = client;
        }

        public void Run(IEnumerable<DocChange<TDoc>> changes)
        {
            var descriptor = new BulkDescriptor();

            var indexName = "WaterPointElasticSearch";

            foreach (var c in changes)
            {
                switch (c.Type)
                {
                    case DocChangeTypes.EditOrCreate:
                        descriptor.Index<TDoc>(doc => doc
                            .Document(c.Doc)
                            .Index(indexName)
                            .Routing(c.Doc.OrganizationId.ToString(CultureInfo.InvariantCulture)));
                        break;

                    case DocChangeTypes.Remove:
                        descriptor.Delete<TDoc>(doc => doc
                            .Document(c.Doc)
                            .Index(indexName));
                        break;
                }
            }

            var response = _client.Bulk(descriptor);

            if (!response.Errors && response.IsValid)
                return;

            var errors = response.ItemsWithErrors
                .Select(e => new Exception(e.Error.Reason))
                .ToList();

            throw new AggregateException(errors);
        }
    }
}
