using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Core.Contract;
using WaterPoint.Core.Domain;
using WaterPoint.Core.Domain.DataProvider;

namespace WaterPoint.App.DataProvider
{
    //TODO: bind uri to apiclient
    public class OrganizationApiDataProvider : ApiDataProvider, IOrganizationApiDataProvider
    {
        private const string Organizations = "organizations";

        public OrganizationApiDataProvider(IApiClient client)
            : base(client)
        {
            Client.Context.AppendToUri(Organizations);
        }

        public async Task<OrganizationContract> GetByIdAsync(int id)
        {
            Client.Context.AppendToUri(id);

            var result = await Client.Get<OrganizationContract>();

            return result;
        }
    }
}
