using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace WaterPoint.ApiClient
{
    public class ApiClient : IApiClient, IDisposable
    {
        private const string ApplicationJson = "application/json";
        private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

        private readonly WebClient _client;

        public IApiContext Context { get; private set; }

        public ApiClient(IApiContext context)
        {
            _client = new WebClient();

            Context = context;
        }

        public async Task<T> Get<T>() where T : class
        {
            using (_client)
            {
                var streamResponse = await _client.OpenReadTaskAsync(Context.EndpointUri);

                if (streamResponse == null)
                    throw new InvalidOperationException();

                using (var sr = new StreamReader(streamResponse))
                {
                    var stringResponse = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<T>(stringResponse);
                }
            }
        }

        public async Task<T> Post<T>() where T : class
        {
            return await Execute<T>(HttpMethod.Post, Context.Payload);
        }

        public async Task<T> Delete<T>() where T : class
        {
            return await Execute<T>(HttpMethod.Delete, Context.Payload);
        }

        public async Task<T> Put<T>() where T : class
        {
            return await Execute<T>(HttpMethod.Put, Context.Payload);
        }

        private async Task<T> Execute<T>(string method, string payload)
        {
            using (_client)
            {
                _client.Headers[HttpRequestHeader.ContentType] = ApplicationJson;

                var result = await _client.UploadStringTaskAsync(Context.EndpointUri, method, payload);

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        ~ApiClient()
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
