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
        public OrganizationApiDataProvider(IApiClient client)
            : base(client)
        {
        }

        public async Task<OrganizationContract> GetByIdAsync(int id, string action)
        {
            //Client.Context.Append("");
            //Client.Context.SetPayload(

            var result = await Client.Get<OrganizationContract>();

            return result;
        }
    }
}
