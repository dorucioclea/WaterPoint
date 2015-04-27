using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;
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

    //TODO: bind uri to apiclient
    public class OrganizationApiDataProvider : ApiDataProvider
    {
        public OrganizationApiDataProvider(IApiClient client)
            : base(client)
        {
        }

        public async Task<OrganizationContract> GetByIdAsync(int id, string action)
        {
            var result = await Client.Get<OrganizationContract>("me");

            return result;
        }
    }
}
