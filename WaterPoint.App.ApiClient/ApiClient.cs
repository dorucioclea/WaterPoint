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
    internal class ApiClient
    {
        private const string ApplicationJson = "application/json";

        private const string ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";

        public ApiClient()
        {            
        }

        public async Task<string> Get(Uri uri)
        {
            using (var client = new WebClient())
            {
                var stream = client.OpenRead(uri);

                var reader = new StreamReader(stream);

                var response = await reader.ReadToEndAsync();

                return response;
            }
        }

        public async Task<string> SubmitAsJson(Uri uri, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = ApplicationJson;

                var result = await wc.UploadStringTaskAsync(uri, "post", jsonData);

                return result;
            }
        }

        public async Task<string> SubmitAsForm(Uri uri, object data)
        {
            var postData = data.ToDictionary();

            var nv = HttpUtility.ParseQueryString(string.Empty);

            foreach(var p in postData)
                nv.Add(p.Key, p.Value.ToString());

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = ApplicationFormUrlEncoded;

                var result = await wc.UploadStringTaskAsync(uri, "post", nv.ToString());

                return result;
            }
        }
    }
}
