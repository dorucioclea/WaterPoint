using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.ApiClient
{
    public class ApiContext : IApiContext
    {
        public ApiContext(Uri baseUri)
        {
            if (baseUri == null)
                throw new ArgumentNullException("baseUri");

            BaseUri = baseUri;

            EndpointUri = BaseUri;
        }

        public Uri BaseUri { get; private set; }

        public Uri EndpointUri { get; private set; }

        public string Payload { get; private set; }

        //public IDictionary<string, object> Parameters { get; private set; }

        public IApiContext AppendToUri(int urlNode)
        {
            return AppendToUri(urlNode.ToString());
        }

        public IApiContext AppendToUri(string urlNode)
        {
            EndpointUri = new Uri(EndpointUri, urlNode);

            return this;
        }

        public IApiContext SetPayload(object payload, Func<object, string> serializer)
        {
            Payload = serializer.Invoke(payload);

            return this;
        }

        //public IApiContext SetParameters(object parameters)
        //{
        //    Parameters = parameters.ToDictionary();

        //    return this;
        //}
    }
}
