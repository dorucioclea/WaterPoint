using System;
using Elasticsearch.Net;
using Nest;

namespace WaterPoint.ElasticSearch
{
    public static class ElasticsearchConnectionHelper
    {
        private static readonly ConnectionSettings ConnSettings;

        static ElasticsearchConnectionHelper()
        {
            var uri = new Uri("http://localhost:9200");

            ConnSettings = new ConnectionSettings(new SniffingConnectionPool(new[] {uri}))
                .EnableHttpCompression(false);
        }

        public static ElasticClient Build()
        {
            return new ElasticClient(ConnSettings);
        }
    }
}
