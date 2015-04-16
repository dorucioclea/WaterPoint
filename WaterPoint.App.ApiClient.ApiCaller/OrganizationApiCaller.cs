using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WaterPoint.Api.DataContract;
using WaterPoint.App.ApiClient.ApiCaller.Interfaces;
using WaterPoint.App.ApiClient.Endpoints.Interfaces;

namespace WaterPoint.App.ApiClient.Endpoints
{
    public class OrganizationApiClient : ApiClientBase, IOrganizationApiClient, IApiCaller
    {
        private const string BaseUri = "http://localhost/WaterPoint.Api";

        public OrganizationApiClient(Uri baseUri)
            : base(baseUri)
        {
        }

        public async Task<OrganizationContract> GetById(int id)
        {
            var action = id.ToString();

            var result = await Get<OrganizationContract>(action);

            return result;
        }
    }
}
