using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace WaterPoint.ApiClient
{
    class ApiContext
    {
        public Uri Uri { get; set; }
        public IDictionary<HttpRequestHeader, string> Headers { get; set; }
        public object Data { get; set; }
    }

    public class ApiClientHandler : IApiClient, IDisposable
    {
        private const string ApplicationJson = "application/json";
        private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";
        //httputility.parsequerystring
        private readonly WebClient _client;
        private readonly ApiContext _context;

        public ApiClientHandler()
        {
            _client = new WebClient();
            _context = new ApiContext();
        }

        public IApiClient SetUri(Uri uri)
        {
            _context.Uri = uri;

            return this;
        }

        public IApiClient AddHeader(HttpRequestHeader header, string value)
        {
            if (_context.Headers == null)
                _context.Headers = new Dictionary<HttpRequestHeader, string>();

            _context.Headers.Add(header, value);

            return this;
        }

        public IApiClient SetData(object data)
        {
            _context.Data = data;

            return this;
        }

        public async Task<T> Get<T>() where T : class
        {
            using (_client)
            {
                var streamResponse = await _client.OpenReadTaskAsync(_context.Uri)
                    .ConfigureAwait(false);

                if (streamResponse == null)
                    throw new InvalidOperationException();

                using (var sr = new StreamReader(streamResponse))
                {
                    var stringResponse = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<T>(stringResponse);
                }
            }
        }

        public async Task<T> Post<T>(T payloadObject) where T : class
        {
            var payload = JsonConvert.SerializeObject(payloadObject);

            return await Execute<T>(HttpMethod.Post, payload);
        }

        public async Task<T> Delete<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> Put<T>(T payloadObject) where T : class
        {
            var payload = JsonConvert.SerializeObject(payloadObject);

            return await Execute<T>(HttpMethod.Put, payload);
        }

        private async Task<T> Execute<T>(string method, string payload)
        {
            using (_client)
            {
                var result = await _client.UploadStringTaskAsync(_context.Uri, method, payload);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        ~ApiClientHandler()
        {
            Dispose();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
