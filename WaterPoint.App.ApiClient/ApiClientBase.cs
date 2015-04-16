using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Utility;

namespace WaterPoint.App.ApiClient
{
    internal sealed class HttpMethod
    {
        internal const string Get = "get";
        internal const string Post = "post";
        internal const string Put = "put";
        internal const string Delete = "delete";
    }

    public abstract class ApiClientBase : IDisposable
    {
        private const string ApplicationJson = "application/json";
        private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

        private readonly WebClient _client;

        private readonly Uri _baseUri;

        protected ApiClientBase(Uri baseUri)
        {
            _client = new WebClient();

            _baseUri = baseUri;
        }

        protected WebClient Client
        {
            get { return _client; }
        }

        protected async Task<T> Get<T>(string action) where T : class
        {
            using (_client)
            {
                var uri = new Uri(_baseUri, action);

                var streamResponse = await _client.OpenReadTaskAsync(uri);

                if (streamResponse == null)
                    throw new InvalidOperationException();

                using (var sr = new StreamReader(streamResponse))
                {
                    var stringResponse = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<T>(stringResponse);
                }
            }
        }

        protected async Task<T> Post<T>(string action, object data) where T : class
        {
            return await Execute<T>(action, HttpMethod.Post, data);
        }

        protected async Task<T> Delete<T>(string action, object data) where T : class
        {
            return await Execute<T>(action, HttpMethod.Delete, data);
        }

        protected async Task<T> Put<T>(string action, object data) where T : class
        {
            return await Execute<T>(action, HttpMethod.Put, data);
        }

        private async Task<T> Execute<T>(string action, string method, object data)
        {
            using (_client)
            {
                var uri = new Uri(_baseUri, action);

                var serialized = string.Empty;

                if (data != null)
                    serialized = JsonConvert.SerializeObject(data);

                _client.Headers[HttpRequestHeader.ContentType] = ApplicationJson;

                var result = await _client.UploadStringTaskAsync(uri, method, serialized);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        ~ApiClientBase()
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
