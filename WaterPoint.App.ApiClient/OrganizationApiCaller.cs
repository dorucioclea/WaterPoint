using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WaterPoint.App.ApiClient
{
    public class OrganizationApiCaller
    {
        private const string ApplicationJson = "application/json";

        public void test()
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = ApplicationJson;
            }            
        }
    }
}
