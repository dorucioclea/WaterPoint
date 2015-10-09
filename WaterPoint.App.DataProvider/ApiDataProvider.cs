using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.ApiClient;
using WaterPoint.Core.Domain;

namespace WaterPoint.App.DataProvider
{
    public class ApiDataProvider
    {
        public IApiClient Client { get; private set; }

        public ApiDataProvider(IApiClient client)
        {
            Client = client;
        }
    }
}
